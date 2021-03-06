//    Copyright 2009 Wii Device Library authors
//
//    This file is part of Wii Device Library.
//
//    Wii Device Library is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.
//
//    Wii Device Library is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with Wii Device Library.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Text;

namespace WiiDeviceLibrary.Bluetooth.Bluesoleil
{
    public class BluetoothConnection
    {
        #region Properties
        private BluesoleilService owner;
        public BluesoleilService Owner
        {
            get { return owner; }
        }

        private BluetoothService service;
        public BluetoothService Service
        {
            get { return service; }
        }

        private int connectionHandle;
        internal int ConnectionHandle
        {
            get { return connectionHandle; }
        }

        private BluetoothConnectionStatus status;
        public BluetoothConnectionStatus Status
        {
            get { return status; }
            internal set
            {
                if (status != value)
                {
                    status = value;
                    OnStatusChanged(EventArgs.Empty);
                }
            }
        }
        #endregion

        #region Constructors
        internal BluetoothConnection(BluesoleilService owner, BluetoothService service, int connectionHandle)
        {
            this.owner = owner;
            this.service = service;
            this.connectionHandle = connectionHandle;
        }
        #endregion

        #region StatusChanged Event
        protected virtual void OnStatusChanged(EventArgs e)
        {
            if (StatusChanged == null)
                return;
            StatusChanged(this, e);
        }
        public event EventHandler<EventArgs> StatusChanged;
        #endregion
    }
}
