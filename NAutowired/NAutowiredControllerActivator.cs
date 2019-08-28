﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Internal;
using NAutowired.Core;

namespace NAutowired
{
    public class NAutowiredControllerActivator : DefaultControllerActivator
    {
        public NAutowiredControllerActivator(ITypeActivatorCache typeActivatorCache) : base(typeActivatorCache)
        {
        }

        public override object Create(ControllerContext actionContext)
        {
            //default create controller function
            var controllerInstance = base.Create(actionContext);
            DependencyInjection.Resolve(actionContext.HttpContext.RequestServices, controllerInstance);
            return controllerInstance;
        }

        public override void Release(ControllerContext context, object controller)
        {
            base.Release(context, controller);
        }
    }
}
