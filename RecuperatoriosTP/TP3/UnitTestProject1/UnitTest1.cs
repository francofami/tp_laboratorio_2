using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;


namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Prueba que salga una excepcion de tipo AlumnoRepetido al agregar dos alumnos iguales a una universidad
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(AlumnoRepetidoException))]
        public void TestMethodExcepcionAlumnoRepetido()
        {
            Alumno a1 = new Alumno(1, "Jason", "Becker", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Alumno a2 = new Alumno(2, "Jason", "Becker", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);

            Universidad u1 = new Universidad();

            u1 += a1;
            u1 += a2;

            Assert.AreEqual(a1, a2);
        }

        /// <summary>
        /// Prueba que salga una excepcion de tipo ArchivosException al especificar erroneamente la ruta de guardado
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArchivosException))]
        public void TestMethodExcepcionArchivos()
        {
            Texto txt = new Texto();

            txt.Guardar("", "");
        }

        /// <summary>
        /// Prueba que salga una excepcion de tipo DniInvalidoException al crear un dni que excede la cantidad de caracteres permitida
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void TestMethodExcepcionDNI()
        {
            Alumno a1 = new Alumno(1, "Marty", "Friedman", "99999999999999999", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Prueba que salga una excepcion de tipo NacionalidadInvalidaException al crear alumno extranjero con dni de argentino
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void TestMethodExcepcionNacionalidad()
        {
            Alumno a1 = new Alumno(1, "Randy", "Rhoads", "1", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
        }

        /// <summary>
        /// Prueba que salga una excepcion de tipo SinProfesorException al asignar una clase sin haber un profesor que la dicte
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(SinProfesorException))]
        public void TestMethodExcepcionSinProfesor()
        {
            Universidad u1 = new Universidad();
            u1 += Universidad.EClases.Laboratorio;
        }

        /// <summary>
        /// Prueba que el DNI ingresado sea un valor numerico
        /// </summary>
        [TestMethod]
        public void TestNumerico()
        {
            Alumno a1 = new Alumno(1, "Jeff", "Hanneman", "90000000", Persona.ENacionalidad.Extranjero, Universidad.EClases.Laboratorio);
            Assert.AreEqual(a1.DNI, 90000000);
        }

        /// <summary>
        /// Prueba que no haya valores nulos en las clases
        /// </summary>
        [TestMethod]
        public void TestNulos()
        {
            Alumno a1 = new Alumno(1, "Joe", "Satriani", "123", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
            Profesor p1 = new Profesor(1, "Steve", "Vai", "124", Persona.ENacionalidad.Argentino);
            Jornada j1 = new Jornada(Universidad.EClases.Laboratorio, p1);
            Universidad u1 = new Universidad();

            Assert.AreNotEqual(a1, null);
            Assert.AreNotEqual(p1, null);
            Assert.AreNotEqual(j1, null);
            Assert.AreNotEqual(u1, null);
        }
    }
}
