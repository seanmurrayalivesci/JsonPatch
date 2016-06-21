using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using JsonPatch.Paths;

namespace JsonPatch
{
	public class JsonPatchDocumentWithCommands<T, TEntity> : IJsonPatchCommands<T, TEntity>, IJsonPatchDocument where TEntity : class, new()
	{
		private List<JsonPatchOperation> _operations = new List<JsonPatchOperation>();

		public List<JsonPatchOperation> Operations { get { return _operations; } }

		public bool HasOperations { get { return _operations.Count > 0; } }

		public void Add(string path, object value)
		{
			throw new NotImplementedException("Move Operation not supported.");
		}

		public void Replace(string path, object value)
		{
			_operations.Add(new JsonPatchOperation
				{
					Operation = JsonPatchOperationType.replace,
					Path = path,
					ParsedPath = null,
					Value = value
				});
		}

		public void Remove(string path)
		{
			throw new NotImplementedException("Move Operation not supported.");
		}

		public void Move(string from, string path)
		{
			throw new NotImplementedException("Move Operation not supported.");
		}

		public IEnumerable<T> ToCommands(TEntity entity, ICommandMapper<T, TEntity> commandMapper)
		{
			var commands = new List<T>();
			foreach (var operation in _operations)
			{
				switch(operation.Operation)
				{
				case JsonPatchOperationType.replace:
					commands.Add(commandMapper.GetCommandFromPathAndOp(typeof(TEntity), operation.Path, entity, operation.Value, JsonPatchOperationType.replace));
					break;
				default:
					throw new NotSupportedException("Operation not supported.");
				}
			}
			return commands;
		}
	}
}
