﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Hobbisoft.Slam.DynamicInjection.UnitTests.Classes
{
    public class ExternalClass
    {
        //public ExternalClass()
        //{
        //    InjectionHelper.Log("pre Slam");
        //    Injector.Slam( this);

        //}
        [MethodImpl(MethodImplOptions.NoInlining)]
        [HandleProcessCorruptedStateExceptions]
        public string ImExternal()
        {
        
            return "I'm in dll #1";
        }

    }
}
