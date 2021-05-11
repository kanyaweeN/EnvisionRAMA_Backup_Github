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
using RIS.DataAccess.Insert;
namespace RIS.BusinessLogic
{
	public class ProcessAddRISUserorgmap : IBusinessLogic
	{
		private RISUserorgmap _risuserorgmap;
		private bool useTran;
		public ProcessAddRISUserorgmap()
		{
			_risuserorgmap = new  RISUserorgmap();
			useTran=false;
		}
		public RISUserorgmap RISUserorgmap
		{
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
			RISUserorgmapInsertData _proc=new RISUserorgmapInsertData();
			_proc.RISUserorgmap=this.RISUserorgmap;
			useTran= useTran ? _proc.Add(useTran,true) : _proc.Add();
		}
	}
}

