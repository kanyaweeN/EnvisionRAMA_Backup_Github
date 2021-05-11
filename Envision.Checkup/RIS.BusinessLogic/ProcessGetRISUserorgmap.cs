//---------------------------------------------------------------------------------------------
//         Description.
//---------------------------------------------------------------------------------------------
//         Create by  :    
//         Email      :    
//         Generate   :    25/02/2009 11:11:57
//         Objecttive :    
//---------------------------------------------------------------------------------------------
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using RIS.Common;
using RIS.DataAccess.Select;
namespace RIS.BusinessLogic
{
	public class ProcessGetRISUserorgmap : IBusinessLogic
	{
		private DataSet result;
		private RISUserorgmap _risuserorgmap;
		public ProcessGetRISUserorgmap()
		{
			_risuserorgmap = new  RISUserorgmap();
		}
		public RISUserorgmap RISUserorgmap
		{
			get{return _risuserorgmap;}
			set{_risuserorgmap=value;}
		}
		public DataSet Result
		{
			get{return result;}
			set{result=value;}
		}
		public void Invoke()
		{
			RISUserorgmapSelectData _proc=new RISUserorgmapSelectData();
			_proc.RISUserorgmap=this.RISUserorgmap;
			result=_proc.GetData();
		}
	}
}

