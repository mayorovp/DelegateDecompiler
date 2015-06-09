using DelegateDecompiler.EntityFramework.Tests.EfItems;
using NUnit.Framework;
using System.Data.Entity;
using System.Linq;

namespace DelegateDecompiler.EntityFramework.Tests
{
	[TestFixture]
	public class ComputeIncludeDecompileTest
	{
		[Test]
		public void ComputeIncludeDecompileNotFail()
		{
			using (var db = new EfTestDbContext())
			{
				db.EfParents.Where(p => ComputedSample()).Include(p => p.Children).Decompile().Load();
			}
		}

		[Test]
		public void ComputeDoubleIncludeDecompileNotFail()
		{
			using (var db = new EfTestDbContext())
			{
				db.EfParents.Where(p => ComputedSample()).Include(p => p.Children).Include(p => p.Children).Decompile().Load();
			}
		}

		[Computed]
		private static bool ComputedSample() { return true; }
	}
}
