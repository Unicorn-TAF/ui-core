﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Unicorn.UI.Core.Controls;

namespace Unicorn.UI.Core.Driver
{
    /// <summary>
    /// Describes base generic search context for UI controls <see cref="IControl"/>.
    /// </summary>
    public abstract class BaseSearchContext<U> : ISearchContext where U : BaseSearchContext<U>
    {
        /// <summary>
        /// Gets or sets control parent search context (context from which current control was searched for).
        /// </summary>
        /** It's ugly, but <see cref="InternalResources.ParentContext"/> refers to this property name **/
        public U ParentSearchContext { get; set; }

        /// <summary>
        /// Gets default implicit wait timeout (30 seconds)
        /// </summary>
        protected static TimeSpan TimeoutDefault { get; } = TimeSpan.FromSeconds(30);

        /// <summary>
        /// Gets or sets current implicit wait timeout.
        /// For correct timeout restoring after TryGetChild call this property should be set 
        /// </summary>
        protected abstract TimeSpan ImplicitWaitTimeout { get; set; }

        /// <summary>
        /// Gets type of basic control for specific UI module implementation.
        /// </summary>
        protected abstract Type ControlsBaseType { get; }

        /// <summary>
        /// Finds control of specified type by specified locator during implicitly wait timeout.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <returns>control instance</returns>
        /// <exception cref="ControlNotFoundException">Thrown in case control was not found during implicitly wait timeout</exception>
        public T Find<T>(ByLocator locator) where T : IControl
        {
            CheckForControlType<T>();
            return WaitForWrappedControl<T>(locator);
        }

        /// <summary>
        /// Finds <see cref="IControl"/> by specified locator during implicitly wait timeout.
        /// </summary>
        /// <param name="locator">locator to search by</param>
        /// <returns><see cref="IControl"/> instance</returns>
        /// <exception cref="ControlNotFoundException">Thrown in case control was not found during implicitly wait timeout</exception>
        public IControl Find(ByLocator locator)
        {
            MethodInfo method = GetType().GetMethod(nameof(WaitForWrappedControl),
                BindingFlags.NonPublic | BindingFlags.Instance);

            MethodInfo generic = method.MakeGenericMethod(ControlsBaseType);
            return generic.Invoke(this, new object[] { locator }) as IControl;
        }

        /// <summary>
        /// Finds list of controls of specified type by specified locator during implicitly wait timeout.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <returns>list of controls instances, in case when no controls found empty list is returned</returns>
        public IList<T> FindList<T>(ByLocator locator) where T : IControl
        {
            CheckForControlType<T>();
            return GetWrappedControlsList<T>(locator);
        }

        /// <summary>
        /// Immediately tries to get control by specified locator.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <returns>true - if control was found; otherwise - false</returns>
        public bool TryGetChild<T>(ByLocator locator) where T : IControl =>
            TryGetChild<T>(locator, 0, out T control);

        /// <summary>
        /// Immediately tries to get control by specified locator.
        /// </summary>
        /// <param name="locator">locator to search by</param>
        /// <returns>true - if control was found; otherwise - false</returns>
        public bool TryGetChild(ByLocator locator)
        {
            MethodInfo method = GetType().GetMethods()
                .Where(m => m.IsGenericMethod && m.Name == nameof(TryGetChild))
                .FirstOrDefault();

            MethodInfo generic = method.MakeGenericMethod(ControlsBaseType);
            return (bool)generic.Invoke(this, new object[] { locator });
        }

        /// <summary>
        /// Tries to get control by specified locator during specified timeout.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <param name="millisecondsTimeout">timeout in milliseconds to search for control</param>
        /// <returns>true - if control was found; otherwise - false</returns>
        public bool TryGetChild<T>(ByLocator locator, int millisecondsTimeout) where T : IControl =>
            TryGetChild<T>(locator, millisecondsTimeout, out T control);

        /// <summary>
        /// Tries to get control by specified locator during specified timeout.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <param name="millisecondsTimeout">timeout in milliseconds to search for control</param>
        /// <param name="controlInstance">control instance to return (null if control was not found)</param>
        /// <returns>true - if control was found; otherwise - false</returns>
        public bool TryGetChild<T>(ByLocator locator, int millisecondsTimeout, out T controlInstance) where T : IControl
        {
            TimeSpan initialTimeout = ImplicitWaitTimeout == null ? TimeoutDefault : ImplicitWaitTimeout;
            ImplicitWaitTimeout = TimeSpan.FromMilliseconds(millisecondsTimeout);

            bool isPresented = true;

            try
            {
                controlInstance = Find<T>(locator);
            }
            catch (ControlNotFoundException)
            {
                controlInstance = default;
                isPresented = false;
            }

            ImplicitWaitTimeout = initialTimeout;

            return isPresented;
        }

        /// <summary>
        /// Immediately gets first child from current control.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <returns>control instance</returns>
        public T FirstChild<T>() where T : IControl
        {
            CheckForControlType<T>();
            return GetFirstChildWrappedControl<T>();
        }

        /// <summary>
        /// Gets native control found by specified locator and wraps it with searched control type.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <returns>control instance</returns>
        protected abstract T WaitForWrappedControl<T>(ByLocator locator);

        /// <summary>
        /// Gets native controls list found by specified locator and wraps each with searched control type.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <param name="locator">locator to search by</param>
        /// <returns>list of controls instances</returns>
        protected abstract IList<T> GetWrappedControlsList<T>(ByLocator locator);

        /// <summary>
        /// Gets native first child control and wraps it with searched control type.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <returns>control instance</returns>
        protected abstract T GetFirstChildWrappedControl<T>();

        /// <summary>
        /// Check control type to be assignable from UI implementation base control.
        /// </summary>
        /// <typeparam name="T">control type</typeparam>
        /// <exception cref="ArgumentException">Thrown if control type is not assignable fromUI implementation base control</exception>
        protected void CheckForControlType<T>()
        {
            Type targetControlType = typeof(T);
            if (!ControlsBaseType.IsAssignableFrom(targetControlType))
            {
                throw new ArgumentException($"Illegal type of control: {targetControlType}");
            }
        }
    }
}
