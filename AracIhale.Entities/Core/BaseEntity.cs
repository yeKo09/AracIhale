﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AracIhale.Entities.Core
{
	public class BaseEntity
	{
		[Key]
		public int Id { get; set; }
		public int CreatedBy { get; set; } = 1;
		public DateTime? CreatedDate { get; set; } = DateTime.Now;
		public int? ModifiedBy { get; set; }
		public DateTime? ModifiedDate { get; set; } = DateTime.Now;
		public bool IsActive { get; set; } = true;
		public bool IsDeleted { get; set; } = false;
	}

}
