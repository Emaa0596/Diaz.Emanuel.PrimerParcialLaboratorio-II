﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Productos;

namespace Usuarios
{
    public class Database
    {
        private static string cadena_conexion;
        private SqlConnection conexion;
        private SqlCommand? comando;
        private SqlDataReader? lector;
        public event Action? errorConBaseDeDatos;

        /// <summary>
        /// Inicializa el atributo con el string de conexion para la base de datos sql.
        /// </summary>
        static Database()
        {
            Database.cadena_conexion = "Data Source=DESKTOP-9544MJ9\\SQLEXPRESS;Initial Catalog=productos;Integrated Security=True;Encrypt=False;Trust Server Certificate=True";
        }

        /// <summary>
        /// Inicializa el atributo para conectar a la base de datos asignandole el string de conexion
        /// </summary>
        public Database()
        {
            this.conexion = new SqlConnection(Database.cadena_conexion);
        }

        public bool ProbarConexion()
        {
            bool rta = true;
            try
            {
                this.conexion.Open();
            }
            catch (Exception e)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return rta;
        }

        public List<ProductosAlmacen> ObtenerListaAlmacen()
        {
            List<ProductosAlmacen> lista = new List<ProductosAlmacen>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM productosAlmacen";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    ProductosAlmacen item = new ProductosAlmacen();

                    item.Codigo = (int)lector["codigo"];
                    item.Nombre = lector[1].ToString();
                    item.Precio = (double)lector[2];   
                    item.Cantidad = (int)lector[3];

                    lista.Add(item);
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return lista;
        }

        public List<ProductosPanaderia> ObtenerListaPanaderia()
        {
            List<ProductosPanaderia> lista = new List<ProductosPanaderia>();
            try
            {
                this.comando = new SqlCommand();

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM productosPanaderia";
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    ProductosPanaderia item = new ProductosPanaderia();
                    item.codigo = (int)lector["codigo"];
                    item.nombre = lector[1].ToString();
                    item.precio = (double)(decimal)lector[2];
                    item.cantidad = (int)lector[3];
                    item.peso = (float)(double)lector[4];
                    item.precioFinalPesado = (double)(decimal)lector[5];
                    lista.Add(item);
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return lista;
        }

        public List<ProductosCarniceria> ObtenerListaCarniceria()
        {
            List<ProductosCarniceria> lista = new List<ProductosCarniceria>();

            try
            {
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = "SELECT * FROM productosCarniceria";
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                this.lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    ProductosCarniceria item = new ProductosCarniceria();
                    item.codigo = (int)lector["codigo"];
                    item.nombre = lector[1].ToString();
                    item.precio = (double)(decimal)lector[2];
                    item.cantidad = (int)lector[3];
                    item.peso = (float)(double)lector[4];
                    item.precioFinalPesado = (double)(decimal)lector[5];

                    lista.Add(item);
                }
                lector.Close();
            }
            catch (Exception ex)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
            return lista;
        }

        public void AgregarProductoAlmacen(ProductosAlmacen producto)
        {
            bool coincidencias = true;
            try
            {
                string sql = "INSERT INTO productosAlmacen (codigo, producto, precio, cantidad) VALUES(";
                sql = sql + producto.Codigo.ToString() + ", '" + producto.Nombre + "' ," + producto.Precio.ToString() + "," + producto.Cantidad.ToString() +")";
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    coincidencias = false;
                }
            }
            catch (Exception e)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public void AgregarDatoCarniceriaoPanaderia(ProductosCarniceria? productoCarniceriaoPanaderia)
        {
            bool coincidencia = true;
            string tabla;
            if (productoCarniceriaoPanaderia.GetType() == typeof(ProductosCarniceria)) 
            {
                tabla = "productosCarniceria"; 
            }
            else 
            {
                tabla = "productosPanaderia";
            }  
            try
            {
                string sql = $"INSERT INTO {tabla} (codigo, producto, precio, cantidad, peso, precioFinalPesado) VALUES(";
                sql += productoCarniceriaoPanaderia.Codigo.ToString() + ", '" + productoCarniceriaoPanaderia.Nombre + "' ," + productoCarniceriaoPanaderia.Precio.ToString() + ",";
                sql += productoCarniceriaoPanaderia.Cantidad.ToString() +","+ productoCarniceriaoPanaderia.Peso.ToString() +","+ productoCarniceriaoPanaderia.PrecioFinalPesado.ToString()+")";
                this.comando = new SqlCommand();
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0)
                {
                    coincidencia = false;
                }
            }
            catch (Exception e)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
                coincidencia = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public void ModificarProductoAlmacen(ProductosAlmacen producto)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@codigo", producto.Codigo);
                this.comando.Parameters.AddWithValue("@producto", producto.Nombre);
                this.comando.Parameters.AddWithValue("@precio", producto.Precio);
                this.comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);

                string sql = "UPDATE productosAlmacen ";
                sql += "SET codigo = @codigo, producto = @producto, precio = @precio, cantidad = @cantidad ";
                sql += "WHERE codigo = @codigo";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;
                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();
                if (filasAfectadas == 0 && this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            catch (Exception)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }
        

        public void ModificarProductoCarniceriaOPanaderia(ProductosCarniceria? producto)
        {
            bool rta = true;
            string tabla;
            if (producto.GetType() == typeof(ProductosCarniceria))
            {
                tabla = "productosCarniceria";
            }
            else
            {
                tabla = "productosPanaderia";
            }
            try
            {
                this.comando = new SqlCommand();

                this.comando.Parameters.AddWithValue("@codigo", producto.Codigo);
                this.comando.Parameters.AddWithValue("@producto", producto.Nombre);
                this.comando.Parameters.AddWithValue("@precio", producto.Precio);
                this.comando.Parameters.AddWithValue("@cantidad", producto.Cantidad);
                this.comando.Parameters.AddWithValue("@peso", producto.Peso);
                this.comando.Parameters.AddWithValue("@precioFinalPesado", producto.PrecioFinalPesado);

                string sql = $"UPDATE {tabla} ";
                sql += "SET codigo = @codigo, producto = @producto, precio = @precio, cantidad = @cantidad, peso = @peso, precioFinalPesado =  @precioFinalPesado ";
                sql += "WHERE codigo = @codigo";

                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;

                this.conexion.Open();

                int filasAfectadas = this.comando.ExecuteNonQuery();

                if (filasAfectadas == 0)
                {
                    rta = false;
                }
            }
            catch (Exception)
            {
                if (this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
                rta = false;
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public void EliminarProducto(int codigoDeProducto, string tabla)
        {
            try
            {
                this.comando = new SqlCommand();
                this.comando.Parameters.AddWithValue("@codigo", codigoDeProducto);
                string sql = $"DELETE FROM {tabla} ";
                sql += "WHERE codigo = @codigo";
                this.comando.CommandType = CommandType.Text;
                this.comando.CommandText = sql;
                this.comando.Connection = this.conexion;
                this.conexion.Open();
                int rowsAffected = comando.ExecuteNonQuery();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("No se encontró el producto con el código especificado.");
                }
            }
            catch (Exception)
            {
                if(this.errorConBaseDeDatos != null)
                {
                    this.errorConBaseDeDatos.Invoke();
                }
            }
            finally
            {
                if (this.conexion.State == ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

    }
}
