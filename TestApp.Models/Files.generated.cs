#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using TestApp.Models;

namespace TestApp.Models	
{
	public partial class Files
	{
		private long _id;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual long Id
		{
			get
			{
				return this._id;
			}
			set
			{
				this._id = value;
			}
		}
		
		private string _fileName;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FileName
		{
			get
			{
				return this._fileName;
			}
			set
			{
				this._fileName = value;
			}
		}
		
		private string _fileTitle;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FileTitle
		{
			get
			{
				return this._fileTitle;
			}
			set
			{
				this._fileTitle = value;
			}
		}
		
		private string _filePath;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FilePath
		{
			get
			{
				return this._filePath;
			}
			set
			{
				this._filePath = value;
			}
		}
		
		private string _fileId;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FileId
		{
			get
			{
				return this._fileId;
			}
			set
			{
				this._fileId = value;
			}
		}
		
		private string _fileSize;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string FileSize
		{
			get
			{
				return this._fileSize;
			}
			set
			{
				this._fileSize = value;
			}
		}
		
		private string _dateUploaded;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual string DateUploaded
		{
			get
			{
				return this._dateUploaded;
			}
			set
			{
				this._dateUploaded = value;
			}
		}
		
		private long _userId;
		[System.ComponentModel.DataAnnotations.Required()]
		public virtual long UserId
		{
			get
			{
				return this._userId;
			}
			set
			{
				this._userId = value;
			}
		}
		
		private Entity _entity;
		public virtual Entity Entity
		{
			get
			{
				return this._entity;
			}
			set
			{
				this._entity = value;
			}
		}
		
	}
}
#pragma warning restore 1591