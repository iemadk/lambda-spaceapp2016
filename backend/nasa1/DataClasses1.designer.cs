﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace nasa1
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Database1")]
	public partial class DataClasses1DataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    #endregion
		
		public DataClasses1DataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["Database1ConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DataClasses1DataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<sensorReading> sensorReadings
		{
			get
			{
				return this.GetTable<sensorReading>();
			}
		}
		
		public System.Data.Linq.Table<uvIndex> uvIndexes
		{
			get
			{
				return this.GetTable<uvIndex>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.sensorReadings")]
	public partial class sensorReading
	{
		
		private System.Nullable<System.DateTime> _readingDate;
		
		private string _host;
		
		private System.Nullable<int> _UV;
		
		private System.Nullable<long> _area;
		
		private System.Nullable<int> _sensorError;
		
		public sensorReading()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_readingDate", DbType="DateTime")]
		public System.Nullable<System.DateTime> readingDate
		{
			get
			{
				return this._readingDate;
			}
			set
			{
				if ((this._readingDate != value))
				{
					this._readingDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_host", DbType="NVarChar(50)")]
		public string host
		{
			get
			{
				return this._host;
			}
			set
			{
				if ((this._host != value))
				{
					this._host = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UV", DbType="Int")]
		public System.Nullable<int> UV
		{
			get
			{
				return this._UV;
			}
			set
			{
				if ((this._UV != value))
				{
					this._UV = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_area", DbType="BigInt")]
		public System.Nullable<long> area
		{
			get
			{
				return this._area;
			}
			set
			{
				if ((this._area != value))
				{
					this._area = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_sensorError", DbType="Int")]
		public System.Nullable<int> sensorError
		{
			get
			{
				return this._sensorError;
			}
			set
			{
				if ((this._sensorError != value))
				{
					this._sensorError = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.uvIndexs")]
	public partial class uvIndex
	{
		
		private System.DateTime _readingDate;
		
		private string _host;
		
		private int _UV;
		
		private long _area;
		
		private int _UVI;
		
		public uvIndex()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_readingDate", DbType="DateTime NOT NULL")]
		public System.DateTime readingDate
		{
			get
			{
				return this._readingDate;
			}
			set
			{
				if ((this._readingDate != value))
				{
					this._readingDate = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_host", DbType="NVarChar(50) NOT NULL", CanBeNull=false)]
		public string host
		{
			get
			{
				return this._host;
			}
			set
			{
				if ((this._host != value))
				{
					this._host = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UV", DbType="Int NOT NULL")]
		public int UV
		{
			get
			{
				return this._UV;
			}
			set
			{
				if ((this._UV != value))
				{
					this._UV = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_area", DbType="BigInt NOT NULL")]
		public long area
		{
			get
			{
				return this._area;
			}
			set
			{
				if ((this._area != value))
				{
					this._area = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UVI", DbType="Int NOT NULL")]
		public int UVI
		{
			get
			{
				return this._UVI;
			}
			set
			{
				if ((this._UVI != value))
				{
					this._UVI = value;
				}
			}
		}
	}
}
#pragma warning restore 1591
