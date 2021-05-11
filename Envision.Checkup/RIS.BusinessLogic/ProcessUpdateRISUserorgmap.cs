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
using RIS.DataAccess.Update;
namespace RIS.BusinessLogic
{
	public class ProcessUpdateRISUserorgmap : IBusinessLogic
	{
		private RISUserorgmap _risuserorgmap;
		private bool useTran;
		public ProcessUpdateRISUserorgmap()
		{
			_risuserorgmap = new RISUserorgmap();
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
			RISUserorgmapUpdateData _proc=new RISUserorgmapUpdateData();
			_proc.RISUserorgmap=this.RISUserorgmap;
			useTran= useTran ?_proc.Update(useTran,true):_proc.Update();
		}
	}
}

