using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;

namespace AVC
{
	// Token: 0x02000012 RID: 18
	public class XDataMan
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00009ED2 File Offset: 0x000080D2
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00009EDA File Offset: 0x000080DA
		[Browsable(false)]
		internal virtual string XDAppName { get; private set; }

		// Token: 0x060000BA RID: 186 RVA: 0x00009EE3 File Offset: 0x000080E3
		internal XDataMan()
		{
		}

		// Token: 0x060000BB RID: 187 RVA: 0x00009EEB File Offset: 0x000080EB
		internal XDataMan(ObjectId A_0, Transaction A_1)
		{
			this.a(A_0, A_1);
		}

		// Token: 0x060000BC RID: 188 RVA: 0x00009EFC File Offset: 0x000080FC
		internal XDataMan(DBObject A_0)
		{
			if (A_0 == null)
			{
				return;
			}
			this.a(A_0);
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00009F16 File Offset: 0x00008116
		// (set) Token: 0x060000BE RID: 190 RVA: 0x00009F1E File Offset: 0x0000811E
		[Browsable(false)]
		internal virtual ResultBuffer Buffer { get; set; }

		// Token: 0x060000BF RID: 191 RVA: 0x00009F27 File Offset: 0x00008127
		internal virtual void Clear()
		{
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x00009F2C File Offset: 0x0000812C
		internal bool a(DBObject A_0)
		{
			this.Clear();
			if (A_0 == null)
			{
				return false;
			}
			using (ResultBuffer xdataForApplication = A_0.GetXDataForApplication(this.XDAppName))
			{
				if (xdataForApplication == null)
				{
					return false;
				}
				this.Buffer = xdataForApplication;
			}
			return true;
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x00009F8C File Offset: 0x0000818C
		internal bool a(ObjectId A_0, Transaction A_1)
		{
			this.Clear();
			if (A_0.IsNull || A_0.Database == null)
			{
				return false;
			}
			DBObject @object = A_1.GetObject(A_0, 0);
			return !(@object == null) && this.a(@object);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x00009FD4 File Offset: 0x000081D4
		internal void a(DBObject A_0, Transaction A_1)
		{
			if (A_0 == null || A_0.IsErased || A_0.IsDisposed)
			{
				return;
			}
			this.a(A_0.Database, A_1);
			if (!A_0.IsWriteEnabled && !A_0.ObjectId.IsNull)
			{
				A_1.GetObject(A_0.ObjectId, 1, false, true);
			}
			A_0.XData = this.Buffer;
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x0000A040 File Offset: 0x00008240
		internal void b(ObjectId A_0, Transaction A_1)
		{
			if (A_0.IsNull || A_0.Database == null)
			{
				return;
			}
			DBObject @object = A_1.GetObject(A_0, 1, false, true);
			if (@object != null)
			{
				this.a(A_0.Database, A_1);
				@object.XData = this.Buffer;
			}
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x0000A098 File Offset: 0x00008298
		internal bool a(Database A_0, Transaction A_1)
		{
			if (string.IsNullOrWhiteSpace(this.XDAppName))
			{
				return false;
			}
			if (A_0 == null)
			{
				return this.a(A_1);
			}
			RegAppTable regAppTable = A_1.GetObject(A_0.RegAppTableId, 0) as RegAppTable;
			if (!regAppTable.Has(this.XDAppName))
			{
				RegAppTableRecord regAppTableRecord = new RegAppTableRecord();
				regAppTableRecord.Name = this.XDAppName;
				A_1.GetObject(A_0.RegAppTableId, 1);
				regAppTable.Add(regAppTableRecord);
				A_1.AddNewlyCreatedDBObject(regAppTableRecord, true);
			}
			return true;
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x0000A118 File Offset: 0x00008318
		internal bool a(Transaction A_0)
		{
			if (string.IsNullOrWhiteSpace(this.XDAppName))
			{
				return false;
			}
			Document mdiActiveDocument = Application.DocumentManager.MdiActiveDocument;
			if (mdiActiveDocument == null)
			{
				return false;
			}
			Database database = mdiActiveDocument.Database;
			bool result;
			using (mdiActiveDocument.a())
			{
				result = this.a(database, A_0);
			}
			return result;
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0000A180 File Offset: 0x00008380
		internal TypedValue[] b(DBObject A_0)
		{
			TypedValue[] result;
			using (ResultBuffer xdataForApplication = A_0.GetXDataForApplication(this.XDAppName))
			{
				if (xdataForApplication != null)
				{
					result = xdataForApplication.AsArray();
				}
				else
				{
					result = new TypedValue[1];
				}
			}
			return result;
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x0000A1D0 File Offset: 0x000083D0
		internal object a(DBObject A_0, int A_1)
		{
			if (A_0.XData == null)
			{
				return null;
			}
			object result;
			using (ResultBuffer xdataForApplication = A_0.GetXDataForApplication(this.XDAppName))
			{
				if (xdataForApplication == null)
				{
					result = null;
				}
				else if (xdataForApplication.AsArray().GetUpperBound(0) < A_1)
				{
					result = null;
				}
				else
				{
					result = xdataForApplication.AsArray()[A_1].Value;
				}
			}
			return result;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x0000A24C File Offset: 0x0000844C
		internal bool a(DBObject A_0, int A_1, object A_2, Transaction A_3)
		{
			if (A_0.XData == null)
			{
				return false;
			}
			bool result;
			using (ResultBuffer xdataForApplication = A_0.GetXDataForApplication(this.XDAppName))
			{
				if (xdataForApplication == null)
				{
					result = false;
				}
				else
				{
					TypedValue[] array = xdataForApplication.AsArray();
					if (array.GetUpperBound(0) < A_1)
					{
						result = false;
					}
					else
					{
						if (A_2 is int)
						{
							array[A_1] = new TypedValue(1071, A_2);
						}
						else
						{
							array[A_1] = new TypedValue(1000, A_2.ToString());
						}
						if (!A_0.IsWriteEnabled && !A_0.ObjectId.IsNull)
						{
							A_3.GetObject(A_0.ObjectId, 1, false, true);
						}
						this.a(A_0.Database, A_3);
						A_0.XData = new ResultBuffer(array);
						result = true;
					}
				}
			}
			return result;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x0000A334 File Offset: 0x00008534
		internal void c(ObjectId A_0, Transaction A_1)
		{
			try
			{
				if (!A_0.IsNull && !A_0.IsErased && A_0.IsValid)
				{
					DBObject @object = A_1.GetObject(A_0, 1, false, true);
					if (!(@object == null))
					{
						this.b(@object, A_1);
					}
				}
			}
			catch
			{
				A_1.Abort();
				ah.b("Объект не доступен для записи. Вероятно заблокирован слой.");
			}
		}

		// Token: 0x060000CA RID: 202 RVA: 0x0000A3A4 File Offset: 0x000085A4
		internal void b(DBObject A_0, Transaction A_1)
		{
			ResultBuffer xdataForApplication = A_0.GetXDataForApplication(this.XDAppName);
			if (xdataForApplication != null)
			{
				if (!A_0.IsWriteEnabled && !A_0.ObjectId.IsNull)
				{
					A_1.GetObject(A_0.ObjectId, 1, false, true);
				}
				this.a(A_0.Database, A_1);
				A_0.XData = this.n();
				xdataForApplication.Dispose();
			}
		}

		// Token: 0x060000CB RID: 203 RVA: 0x0000A410 File Offset: 0x00008610
		internal bool c(DBObject A_0)
		{
			if (A_0 == null)
			{
				return false;
			}
			bool result;
			using (ResultBuffer xdataForApplication = A_0.GetXDataForApplication(this.XDAppName))
			{
				result = (xdataForApplication != null);
			}
			return result;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x0000A45C File Offset: 0x0000865C
		internal bool d(ObjectId A_0, Transaction A_1)
		{
			return this.c(A_1.GetObject(A_0, 0));
		}

		// Token: 0x060000CD RID: 205 RVA: 0x0000A46C File Offset: 0x0000866C
		internal ResultBuffer n()
		{
			return new ResultBuffer(new TypedValue[]
			{
				new TypedValue(1001, this.XDAppName)
			});
		}

		// Token: 0x0400005F RID: 95
		[CompilerGenerated]
		private string a;

		// Token: 0x04000060 RID: 96
		[CompilerGenerated]
		private ResultBuffer b;
	}
}
