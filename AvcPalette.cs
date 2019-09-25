using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Threading;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.ApplicationServices.Core;
using Autodesk.AutoCAD.DatabaseServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.Windows;
using AVC.Properties;

namespace AVC
{
	// Token: 0x0200005E RID: 94
	public class AvcPalette
	{
		// Token: 0x0600041A RID: 1050 RVA: 0x00027AA8 File Offset: 0x00025CA8
		[CommandMethod("AvcPalette")]
		public static void AvcPaletteCommand()
		{
			try
			{
				y.a();
				if (AvcPalette.a == null || AvcPalette.a.IsDisposed)
				{
					CultureInfo currentUICulture = Thread.CurrentThread.CurrentUICulture;
					if (h.e())
					{
						CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
						if (currentUICulture != currentCulture)
						{
							Thread.CurrentThread.CurrentUICulture = currentCulture;
						}
					}
					try
					{
						AvcPalette.c = new a4();
						AvcPalette.a = new PaletteSet("A>V>C>", "AvcPalette", new Guid("29E0BFF2-50E4-4F95-976F-54206038D36E"));
						AvcPalette.a.Style = 62;
						AvcPalette.a.Style |= 128;
						AvcPalette.a.MinimumSize = new Size(150, 25);
						AvcPalette.a.Size = new Size(200, 100);
						AvcPalette.a.StateChanged += new PaletteSetStateEventHandler(AvcPalette.a);
						AvcPalette.a.EnableTransparency(true);
						AvcPalette.a.Icon = Resources.Kit;
						AvcPalette.a.Add("A>V>C>", AvcPalette.c);
						AvcPalette.d();
						AvcPalette.a.Visible = true;
					}
					finally
					{
						if (currentUICulture != Thread.CurrentThread.CurrentUICulture)
						{
							Thread.CurrentThread.CurrentUICulture = currentUICulture;
						}
					}
				}
				else if (AvcPalette.b)
				{
					AvcPalette.a.Close();
					AvcPalette.a.Visible = false;
					AvcPalette.c();
				}
				else
				{
					AvcPalette.a.Activate(0);
					AvcPalette.d();
					AvcPalette.a.Visible = true;
					p.c.i();
				}
			}
			catch (CancelException)
			{
				ah.c();
			}
			catch (WarningException ex)
			{
				ah.a(ex.Message);
			}
			catch (Exception a_)
			{
				ah.a(a_, "");
			}
		}

		// Token: 0x0600041B RID: 1051 RVA: 0x00027CBC File Offset: 0x00025EBC
		private static void a(object A_0, PaletteSetStateEventArgs A_1)
		{
			try
			{
				if (A_1.NewState == null && AvcPalette.b)
				{
					AvcPalette.b();
					AvcPalette.b(Application.DocumentManager.MdiActiveDocument);
					AvcPalette.b = false;
				}
				else if (A_1.NewState == 1 && !AvcPalette.b)
				{
					AvcPalette.c(Application.DocumentManager.MdiActiveDocument);
					AvcPalette.b = true;
				}
			}
			catch (Exception a_)
			{
				ah.a(a_, "");
			}
		}

		// Token: 0x0600041C RID: 1052 RVA: 0x00027D38 File Offset: 0x00025F38
		private static void d()
		{
			Application.DocumentManager.DocumentActivated -= new DocumentCollectionEventHandler(AvcPalette.b);
			Application.DocumentManager.DocumentActivated += new DocumentCollectionEventHandler(AvcPalette.b);
			Application.DocumentManager.DocumentToBeDeactivated -= new DocumentCollectionEventHandler(AvcPalette.a);
			Application.DocumentManager.DocumentToBeDeactivated += new DocumentCollectionEventHandler(AvcPalette.a);
		}

		// Token: 0x0600041D RID: 1053 RVA: 0x00027D9D File Offset: 0x00025F9D
		private static void c()
		{
			Application.DocumentManager.DocumentActivated -= new DocumentCollectionEventHandler(AvcPalette.b);
			Application.DocumentManager.DocumentToBeDeactivated -= new DocumentCollectionEventHandler(AvcPalette.a);
		}

		// Token: 0x0600041E RID: 1054 RVA: 0x00027DCB File Offset: 0x00025FCB
		private static void c(Document A_0)
		{
			if (A_0 == null)
			{
				return;
			}
			A_0.ImpliedSelectionChanged -= AvcPalette.a;
			A_0.ImpliedSelectionChanged += AvcPalette.a;
		}

		// Token: 0x0600041F RID: 1055 RVA: 0x00027DFB File Offset: 0x00025FFB
		private static void b(Document A_0)
		{
			if (A_0 == null)
			{
				return;
			}
			A_0.ImpliedSelectionChanged -= AvcPalette.a;
		}

		// Token: 0x06000420 RID: 1056 RVA: 0x00027E1C File Offset: 0x0002601C
		private static void a(object A_0, EventArgs A_1)
		{
			try
			{
				if (A_1 == null || !(A_0 is Document))
				{
					AvcPalette.b();
				}
				else
				{
					AvcPalette.a();
					AvcPalette.b();
					AvcPalette.a(A_0 as Document);
				}
			}
			catch (CancelException)
			{
				ah.c();
			}
			catch (WarningException ex)
			{
				ah.a(ex.Message);
			}
			catch (Exception a_)
			{
				AvcPalette.b();
				ah.a(a_, "");
			}
		}

		// Token: 0x06000421 RID: 1057 RVA: 0x00027EA0 File Offset: 0x000260A0
		private static void b()
		{
			if (AvcPalette.a == null || AvcPalette.c == null || !AvcPalette.b)
			{
				return;
			}
			AvcPalette.c.b();
		}

		// Token: 0x06000422 RID: 1058 RVA: 0x00027EC8 File Offset: 0x000260C8
		private static void a()
		{
			if (AvcPalette.a == null || AvcPalette.c == null || !AvcPalette.b)
			{
				return;
			}
			AvcPalette.c.c();
		}

		// Token: 0x06000423 RID: 1059 RVA: 0x00027EF0 File Offset: 0x000260F0
		private static void a(Document A_0)
		{
			if (A_0 == null)
			{
				return;
			}
			PromptSelectionResult promptSelectionResult = null;
			try
			{
				promptSelectionResult = A_0.Editor.SelectImplied();
			}
			catch (Exception ex)
			{
				if (ex.ErrorStatus != 2)
				{
					throw ex;
				}
				promptSelectionResult = null;
			}
			if (promptSelectionResult == null || promptSelectionResult.Status != 5100)
			{
				return;
			}
			AvcPalette.a(new List<ObjectId>(promptSelectionResult.Value.GetObjectIds()));
		}

		// Token: 0x06000424 RID: 1060 RVA: 0x00027F60 File Offset: 0x00026160
		private static void a(List<ObjectId> A_0)
		{
			if (A_0 == null || A_0.Count == 0 || AvcPalette.a == null || AvcPalette.c == null || !AvcPalette.b)
			{
				return;
			}
			if (AvcPalette.c != null)
			{
				AvcPalette.c.a(A_0);
			}
		}

		// Token: 0x06000425 RID: 1061 RVA: 0x00027F9C File Offset: 0x0002619C
		private static void b(object A_0, DocumentCollectionEventArgs A_1)
		{
			try
			{
				if (A_1.Document == null)
				{
					if (AvcPalette.a != null && AvcPalette.b)
					{
						AvcPalette.a.Visible = false;
						AvcPalette.d = true;
					}
				}
				else
				{
					if (AvcPalette.a != null && AvcPalette.b && !AvcPalette.d)
					{
						AvcPalette.c(A_1.Document);
					}
					if (AvcPalette.d && AvcPalette.a != null && !AvcPalette.b)
					{
						AvcPalette.d = false;
						AvcPalette.a.Visible = true;
					}
				}
			}
			catch (CancelException)
			{
				ah.c();
			}
			catch (WarningException ex)
			{
				ah.a(ex.Message);
			}
			catch (Exception a_)
			{
				ah.a(a_, "");
			}
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0002807C File Offset: 0x0002627C
		private static void a(object A_0, DocumentCollectionEventArgs A_1)
		{
			try
			{
				if (!(A_1.Document == null))
				{
					using (A_1.Document.a())
					{
						AvcPalette.a();
					}
					AvcPalette.b();
					if (AvcPalette.b)
					{
						AvcPalette.b(A_1.Document);
					}
				}
			}
			catch (CancelException)
			{
				ah.c();
			}
			catch (WarningException ex)
			{
				ah.a(ex.Message);
			}
			catch (Exception a_)
			{
				ah.a(a_, "");
			}
		}

		// Token: 0x04000225 RID: 549
		private static PaletteSet a;

		// Token: 0x04000226 RID: 550
		private static bool b = false;

		// Token: 0x04000227 RID: 551
		private static a4 c;

		// Token: 0x04000228 RID: 552
		private static bool d = false;

		// Token: 0x04000229 RID: 553
		private static ObjectId e = ObjectId.Null;
	}
}
