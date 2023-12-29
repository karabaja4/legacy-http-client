using System;
using System.Globalization;
using System.Reflection;
using System.Threading.Tasks;

namespace LHC.Library.HttpClient
{
    internal class OnReadyStateChange : IReflect
    {
        private volatile object m_sender;
        private volatile IReflect m_reflect;
        private volatile EventHandler<OnReadyStateChangeEventArgs> m_event;

        private TaskCompletionSource<LegacyHttpResponse> _tcs;

        public OnReadyStateChange(object sender, EventHandler<OnReadyStateChangeEventArgs> eventHandler, TaskCompletionSource<LegacyHttpResponse> tcs)
        {
            this.m_sender = sender;
            this.m_event = eventHandler;
            this.m_reflect = typeof(OnReadyStateChange);
            this._tcs = tcs;
        }

        Type IReflect.UnderlyingSystemType
        {
            get
            {
                return this.m_reflect.UnderlyingSystemType;
            }
        }

        FieldInfo IReflect.GetField(string name, BindingFlags bindingAttr)
        {
            return this.m_reflect.GetField(name, bindingAttr);
        }

        FieldInfo[] IReflect.GetFields(BindingFlags bindingAttr)
        {
            return this.m_reflect.GetFields(bindingAttr);
        }

        MemberInfo[] IReflect.GetMember(string name, BindingFlags bindingAttr)
        {
            return this.m_reflect.GetMember(name, bindingAttr);
        }

        MemberInfo[] IReflect.GetMembers(BindingFlags bindingAttr)
        {
            return this.m_reflect.GetMembers(bindingAttr);
        }

        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr)
        {
            return this.m_reflect.GetMethod(name, bindingAttr);

        }

        MethodInfo IReflect.GetMethod(string name, BindingFlags bindingAttr, Binder binder, Type[] types, ParameterModifier[] modifiers)
        {
            return this.m_reflect.GetMethod(name, bindingAttr, binder, types, modifiers);
        }

        MethodInfo[] IReflect.GetMethods(BindingFlags bindingAttr)
        {
            return this.m_reflect.GetMethods(bindingAttr);
        }

        PropertyInfo[] IReflect.GetProperties(BindingFlags bindingAttr)
        {
            return this.m_reflect.GetProperties(bindingAttr);
        }

        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr)
        {
            return this.m_reflect.GetProperty(name, bindingAttr);
        }

        PropertyInfo IReflect.GetProperty(string name, BindingFlags bindingAttr, Binder binder, Type returnType, Type[] types, ParameterModifier[] modifiers)
        {
            return this.m_reflect.GetProperty(name, bindingAttr);
        }

        object IReflect.InvokeMember(string name, BindingFlags invokeAttr, Binder binder, object target, object[] args, ParameterModifier[] modifiers, CultureInfo culture, string[] namedParameters)
        {
            if (name == "[DISPID=0]" && this.m_event != null)
            {
                this.m_event(this.m_sender, new OnReadyStateChangeEventArgs() { HttpRequestCompleteSource = _tcs });
            }
            return this.m_reflect.InvokeMember(name, invokeAttr, binder, target, args, modifiers, culture, namedParameters);
        }
    }
}
