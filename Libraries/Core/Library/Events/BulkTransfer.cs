﻿//-----------------------------------------------------------------------
// <copyright file="BulkTransfer.cs">
//      Copyright (c) Microsoft Corporation. All rights reserved.
// 
//      THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//      EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
//      MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
//      IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
//      CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
//      TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
//      SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Microsoft.PSharp
{
    /// <summary>
    /// The bulk transfer event.
    /// </summary>
    [DataContract]
    public sealed class BulkTransfer : Event
    {
        /// <summary>
        /// The buffered events.
        /// </summary>
        internal IList<Event> BufferedEvents;

        /// <summary>
        /// Creates a bulk tranfer event from the specified
        /// list of events.
        /// </summary>
        /// <typeparam name="T">Event type</typeparam>
        /// <param name="events">Events</param>
        /// <returns>BulkTransfer</returns>
        public static BulkTransfer Create<T>(IList<T> events) where T : Event
        {
            if (events == null)
            {
                throw new InvalidOperationException(
                    "A bulk transfer cannot contain 'null' events.");
            }

            List<Event> bufferedEvents = events.Cast<Event>().ToList();
            return new BulkTransfer(bufferedEvents);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="events">Events</param>
        private BulkTransfer(IList<Event> events)
            : base()
        {
            this.BufferedEvents = events;
        }
    }
}
