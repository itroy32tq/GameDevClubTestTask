﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Script.Interfaces
{
    public interface ICanTakeItem
    {
        void TakeItem(IItemOnMap item);

        event Action<object, IItemOnMap> OnTakeItemOnMapEvent;
    }
}