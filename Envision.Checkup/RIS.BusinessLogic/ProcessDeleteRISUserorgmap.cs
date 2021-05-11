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
using System.Text;
using RIS.Common;
using RIS.DataAccess.Delete;
namespace RIS.BusinessLogic
{
	public class ProcessDeleteRISUserorgmap : IBusinessLogic
	{
		private RISUserorgmap _risuserorgmap;
		private bool useTran;
		public ProcessDeleteRISUserorgmap()
		{
			_risuserorgmap = new  RISUserorgmap();
			useTran=false;
		}
		public RISUserorgmap RISUserorgmap		{
			get{return _risuserorgmap;}
			set{_risuserorgmap=value;}
		}
		public bool UseTransaction
		{
			get{return useTran;}
			set{useTran=value;}
		}
		public void Invoke()
		{
			RISUserorgmapDeleteData _proc=new RISUserorgmapDeleteData();
			_proc.RISUserorgmap=this.RISUserorgmap;
			useTran= useTran ? _proc.Delete(useTran,true) : _proc.Delete();
		}
	}
}

