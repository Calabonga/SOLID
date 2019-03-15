using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_D.Demo
{
	/// <summary>
	/// Простая реализация инверсии управления (Inversion of Control)
	/// </summary>
	public class SimpleIoC
	{
		#region public methods
		/// <summary>
		/// Создает экземпляр класса
		/// </summary>
		public SimpleIoC()
		{
			RegisterInstance(this);
		}

		/// <summary>
		/// Регистрация типа
		/// </summary>
		/// <typeparam name="TType">регистрируемый класс</typeparam>
		public void Register<TType>() where TType : class
		{
			Register<TType, TType>(false, null);
		}

		/// <summary>
		/// Регистрация экземпляра типа
		/// </summary>
		/// <typeparam name="TType">регистрируемый тип</typeparam>
		/// <typeparam name="TLive">экземпляр класса</typeparam>
		public void Register<TType, TLive>() where TLive : class, TType
		{
			Register<TType, TLive>(false, null);
		}

		/// <summary>
		/// Регистрация типа (Singleton)
		/// </summary>
		/// <typeparam name="TType">регистрируемый тип</typeparam>
		public void RegisterSingleton<TType>() where TType : class
		{
			RegisterSingleton<TType, TType>();
		}

		/// <summary>
		/// Регистрация экземпляра типа (Singleton)
		/// </summary>
		/// <typeparam name="TType">регистрируемый тип</typeparam>
		/// <typeparam name="TLive">экземпляр класса</typeparam>
		public void RegisterSingleton<TType, TLive>() where TLive : class, TType
		{
			Register<TType, TLive>(true, null);
		}

		/// <summary>
		/// Регистрация экземпляра
		/// </summary>
		/// <typeparam name="TType">регистрируемый тип</typeparam>
		/// <typeparam name="TLive">экземпляр класса</typeparam>
		public void RegisterInstance<TType>(TType instance) where TType : class
		{
			RegisterInstance<TType, TType>(instance);
		}

		/// <summary>
		/// Регистрация экземпляра и типа
		/// </summary>
		/// <typeparam name="TType">регистрируемый тип</typeparam>
		/// <typeparam name="TLive">экземпляр класса</typeparam>
		/// <param name="instance"></param>
		public void RegisterInstance<TType, TLive>(TLive instance) where TLive : class, TType
		{
			Register<TType, TLive>(true, instance);
		}

		/// <summary>
		/// Разрешение типа
		/// </summary>
		/// <typeparam name="TResolve">разрешаемый тип</typeparam>
		/// <returns>объект</returns>
		public TResolve Resolve<TResolve>()
		{
			return (TResolve)ResolveObject(typeof(TResolve));
		}

		/// <summary>
		/// Возращает объект по типу
		/// </summary>
		/// <param name="type">разрешаемый тип</param>
		/// <returns>объект</returns>
		public object Resolve(Type type)
		{
			return ResolveObject(type);
		}
		#endregion public methods

		#region private methods
		private void Register<TType, TLive>(bool isSingleton, TLive instance)
		{
			Type type = typeof(TType); if (_registeredObjects.ContainsKey(type)) _registeredObjects.Remove(type); _registeredObjects.Add(type, new EnteredObject(typeof(TLive), isSingleton, instance));
		}
		private object ResolveObject(Type type)
		{
			var registeredObject = _registeredObjects[type]; if (registeredObject == null) { throw new ArgumentOutOfRangeException(string.Format("The type {0} has not been registered", type.Name)); } return GetInstance(registeredObject);
		}
		private object GetInstance(EnteredObject registeredObject)
		{
			object instance = registeredObject.SingletonInstance;
			if (instance == null)
			{
				var parameters = ResolveConstructorParameters(registeredObject);
				instance = registeredObject.CreateInstance(parameters.ToArray());
			}
			return instance;
		}
		private IEnumerable<object> ResolveConstructorParameters(EnteredObject registeredObject)
		{
			var constructorInfo = registeredObject.LiveType.GetConstructors().First();
			return constructorInfo.GetParameters().Select(parameter => ResolveObject(parameter.ParameterType));
		}

		/// <summary>
		/// Регистрируемый объект
		/// </summary>
		private class EnteredObject
		{
			private readonly bool _isSinglton;
			public EnteredObject(Type liveType, bool isSingleton, object instance)
			{
				_isSinglton = isSingleton;
				LiveType = liveType;
				SingletonInstance = instance;
			}
			public Type LiveType
			{
				get;
				private set;
			}
			public object SingletonInstance
			{
				get;
				private set;
			}

			public object CreateInstance(params object[] args)
			{
				object instance = Activator.CreateInstance(LiveType, args);
				if (_isSinglton)
					SingletonInstance = instance;
				return instance;
			}
		}
		#endregion private methods

		#region MyRegion
		private readonly IDictionary<Type, EnteredObject> _registeredObjects = new Dictionary<Type, EnteredObject>();
		#endregion
	}
}