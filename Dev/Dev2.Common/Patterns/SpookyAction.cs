/*
*  Warewolf - Once bitten, there's no going back
*  Copyright 2017 by Warewolf Ltd <alpha@warewolf.io>
*  Licensed under GNU Affero General Public License 3.0 or later.
*  Some rights reserved.
*  Visit our website for more information <http://warewolf.io/>
*  AUTHORS <http://warewolf.io/authors.php> , CONTRIBUTORS <http://warewolf.io/contributors.php>
*  @license GNU Affero General Public License <http://www.gnu.org/licenses/agpl-3.0.html>
*/

using Dev2.Common.Interfaces.Patterns;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;



namespace Dev2.Common

{
    /// <summary>
    ///     Base class for all spooky action at a distanced impls
    /// </summary>
    /// <typeparam name="TReflect">The type to be reflected.</typeparam>
    /// <typeparam name="THandle">The type that the ISpookyLoadable.HandlesType() method returns, used as a key.</typeparam>
    public class SpookyAction<TReflect, THandle>
        where TReflect : ISpookyLoadable<THandle>
    {
        private readonly ConcurrentDictionary<THandle, TReflect> _options =
            new ConcurrentDictionary<THandle, TReflect>();

        private bool _initialized;

        /// <summary>
        ///     Private method for intitailizing the list of options
        /// </summary>
        private void Bootstrap()
        {
            Type type = typeof(TReflect);

            List<Type> types =
                type.Assembly.GetTypes()
                    .Where(t => type.IsAssignableFrom(t) && !t.IsAbstract && !t.IsInterface)
                    .ToList();

            foreach (TReflect item in types.Select(t => (TReflect)Activator.CreateInstance(t, true)))
            {
                _options.TryAdd(item.HandlesType(), item);
            }
        }

        /// <summary>
        ///     Find the matching object
        /// </summary>
        /// <param name="typeOf">The type of.</param>
        /// <returns></returns>
        public TReflect FindMatch(THandle typeOf)
        {
            if (!_options.TryGetValue(typeOf, out TReflect result))
            {
                lock (_options)
                {
                    if (!_initialized)
                    {
                        Bootstrap();
                        _initialized = true;
                    }

                    _options.TryGetValue(typeOf, out result);
                }
            }

            return result;
        }

        /// <summary>
        ///     Find all objects
        /// </summary>
        public IList<TReflect> FindAll()
        {
            if (_options.Count == 0)
            {
                lock (_options)
                {
                    if (_options.Count == 0)
                    {
                        Bootstrap();
                    }
                }
            }

            return _options.Values.ToList();
        }
    }
}