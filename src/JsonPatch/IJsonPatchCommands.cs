using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonPatch
{
	public interface IJsonPatchCommands<T, TEntity>
	{
		IEnumerable<T> ToCommands(TEntity entity);
	}
}
