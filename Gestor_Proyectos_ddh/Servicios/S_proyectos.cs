using Dapper;
using Microsoft.Data.SqlClient;

namespace Gestor_Proyectos_ddh.Servicios
{
    public class S_proyectos
    {
        public string conectionString = "workstation id=dbProgra4.mssql.somee.com;packet size=4096;user id=ddh_SQLLogin_1;pwd=cg8dhis1op;data source=dbProgra4.mssql.somee.com;persist security info=False;initial catalog=dbProgra4;TrustServerCertificate=True";
        public void crear_proyecto(Models.Proyectos p)
        {
            using var conection = new SqlConnection(conectionString);     
            var id = conection.QuerySingle<int>($@"
                INSERT INTO PROYECTOS (NOMBRE_PROYECTO, DESCRIPCION, TAREAS, MATERIALES, COSTOS, RESPONSABLE, FECHA_ENTREGA) 
                VALUES (@NOMBRE_PROYECTO, @DESCRIPCION, @TAREAS, @MATERIALES, @COSTOS, @RESPONSABLE, @FECHA_ENTREGA);
                select SCOPE_IDENTITY();", p);
            p.ID_PROYECTO = id;
            
        }

        public void ActualizarProyecto(Models.Proyectos proyecto)
        {
            using var connection = new SqlConnection(conectionString);
            connection.Execute($@"
        UPDATE PROYECTOS 
        SET 
            NOMBRE_PROYECTO = @NOMBRE_PROYECTO, 
            DESCRIPCION = @DESCRIPCION, 
            TAREAS = @TAREAS, 
            MATERIALES = @MATERIALES, 
            COSTOS = @COSTOS, 
            RESPONSABLE = @RESPONSABLE, 
            FECHA_ENTREGA = @FECHA_ENTREGA
        WHERE 
            ID_PROYECTO = @ID_PROYECTO;", proyecto);
        }


        public void EliminarProyecto(int id)
        {
            using var connection = new SqlConnection(conectionString);
            connection.Execute("DELETE FROM PROYECTOS WHERE ID_PROYECTO = @ID_PROYECTO", new { ID_PROYECTO = id });
        }



        public IEnumerable<Models.Proyectos> sel(int id)
        {
            using var conection = new SqlConnection(conectionString);
            return conection.Query<Models.Proyectos>($@"
                SELECT * FROM PROYECTOS");
        }
    }
}
