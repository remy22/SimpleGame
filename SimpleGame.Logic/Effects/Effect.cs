﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleGame.Logic
{
	public interface IEffect
	{
		string CombatMessage();
		void Resolve();
	}
}
