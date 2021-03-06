﻿// ============================================================================================================================= 
// author       : david sexton (@sextondjc | sextondjc.com)
// date         : 2015.12.23 (23:44)
// modified     : 2017-02-19 (22:11)
// licence      : This file is subject to the terms and conditions defined in file 'LICENSE.txt', which is part of this source code package.
// =============================================================================================================================

#region

using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

#endregion

namespace Drapper
{
    /// <summary>
    ///     Basically breaks down into two distinct operations for mutating data/retrieving data
    /// </summary>
    public partial interface IDbCommander : IDisposable
    {
        /// <summary>
        ///     Executes an arbitrary command against the underlying datastore asynchronously.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        Task<bool> ExecuteAsync<T>(Type type, CancellationToken cancellationToken = default(CancellationToken), [CallerMemberName] string method = null);

        /// <summary>
        ///     Executes a potentially state changing operation asynchronously.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">The model.</param>
        /// <param name="type">The type.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        Task<bool> ExecuteAsync<T>(T model, Type type, CancellationToken cancellationToken = default(CancellationToken), [CallerMemberName] string method = null);

        /// <summary>
        ///     Wraps a Func with a TransactionScope object. Doesn't handle async very well at all. Use at your own peril.
        ///     The "passing" test for this method is entirely synchronous in the map Func.
        /// </summary>
        /// <typeparam name="TResult">The type of the result.</typeparam>
        /// <param name="map">The map.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="method">The method.</param>
        /// <returns></returns>
        Task<TResult> ExecuteAsync<TResult>(Func<TResult> map, CancellationToken cancellationToken = default(CancellationToken), [CallerMemberName] string method = null);
    }
}