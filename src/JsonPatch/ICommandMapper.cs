using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace JsonPatch
{
	public interface ICommandMapper<T, TEntity>
	{
		T GetCommandFromPathAndOp(Type type, string path, TEntity entity, object value, JsonPatchOperationType opType);
	}
}