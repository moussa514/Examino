using System.Data.Entity.Infrastructure;
using System.Text;
using System.Xml;

namespace Examino.Models.Utils
{
    public class CreateDiagramModel
    {
        public static void CreateDiagram()
        {
            using (var ctx = new ApplicationDbContext())
            {
                using (
                    var writer =
                        new XmlTextWriter(
                            @"C:\Users\resua\OneDrive\Documents\Visual Studio 2015\Projects\BagnoleDoccasion\Model.edmx",
                            Encoding.Default))
                {
                    EdmxWriter.WriteEdmx(ctx, writer);
                }
            }
        }
    }
}