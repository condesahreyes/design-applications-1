using System.Collections.Generic;

namespace OblDiseño1.Entidades
{
    public class GestorContraseniasCompartidas
    {
        public Usuario duenio { get; set; }

        private Dictionary<Usuario, List<Dupla_UsuarioContrasenia>> contraseniasCompartidasConmigo;
        private Dictionary<Dupla_UsuarioContrasenia, List<Usuario>> contraseniasCompartidasPorMi;

        public GestorContraseniasCompartidas(Usuario usuario)
        {
            this.duenio = usuario;
            this.contraseniasCompartidasConmigo = new Dictionary<Usuario, List<Dupla_UsuarioContrasenia>>();
            this.contraseniasCompartidasPorMi = new Dictionary<Dupla_UsuarioContrasenia, List<Usuario>>();
        }

        private void CompartirContraseniaAUsuario(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            GestorContraseniasCompartidas gestorACompartir = usuarioACompartir.GestorCompartirContrasenia;
            if (gestorACompartir.VerificarQueElUsuarioMeEstaCompartiendoAlgunaContrasenia(duenio))
                gestorACompartir.ObtenerContraseniasCompartidasConmigo()[duenio].Add(duplaACompartir);
            else
                gestorACompartir.MeCompartenLaContraseniaPorPrimeraVez(duenio, duplaACompartir);
        }

        public void funcionCompartir(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            if (VerificarQueLaDuplaEsMia(duplaACompartir))
            {
                if (VerificarQueYaSeCompartioLaContraseniaConElUsuario(duplaACompartir, usuarioACompartir))
                    throw new Exepcion_InvalidUsuarioData("Ya se compartio esta contraseña con el usuario" +
                        usuarioACompartir.Nombre);
                else
                {
                    GuardarLaContraseniaACompartir(duplaACompartir, usuarioACompartir);
                    CompartirContraseniaAUsuario(duplaACompartir, usuarioACompartir);
                }
            }
            else
                throw new Exepcion_InvalidUsuarioData("No existe una contraseña asociada a " +
                    duplaACompartir.Contrasenia + "para este usuario");
        }

        private void GuardarLaContraseniaACompartir(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            if (VerificarQueEstoyCompartiendoLaContraseniaConAlguien(duplaACompartir))
                this.ObtenerContraseniasCompartidasPorMi()[duplaACompartir].Add(usuarioACompartir);
            else
                CompartirContraseniaPorPrimeraVez(duplaACompartir, usuarioACompartir);
        }

        public void MeCompartenLaContraseniaPorPrimeraVez(Usuario usuarioQueMeComparte, Dupla_UsuarioContrasenia duplaQueMeComparte)
        {
            List<Dupla_UsuarioContrasenia> listaConPrimerDupla = new List<Dupla_UsuarioContrasenia>();
            listaConPrimerDupla.Add(duplaQueMeComparte);
            this.ObtenerContraseniasCompartidasConmigo().Add(usuarioQueMeComparte, listaConPrimerDupla);
        }

        public bool VerificarQueElUsuarioMeEstaCompartiendoAlgunaContrasenia(Usuario usuario)
        {
            return (this.ObtenerContraseniasCompartidasConmigo().ContainsKey(usuario));
        }

        public bool VerificarQueLaDuplaEsMia(Dupla_UsuarioContrasenia dupla)
        {
            return duenio.ObtenerDuplas().Contains(dupla);
        }

        public bool VerificarQueYaSeCompartioLaContraseniaConElUsuario(Dupla_UsuarioContrasenia dupla, Usuario usuario)
        {
            return (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla) &&
                    this.ObtenerContraseniasCompartidasPorMi()[dupla].Contains(usuario));
        }

        public bool VerificarQueEstoyCompartiendoLaContraseniaConAlguien(Dupla_UsuarioContrasenia dupla)
        {
            return (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla));
        }

        public void CompartirContraseniaPorPrimeraVez(Dupla_UsuarioContrasenia duplaACompartir, Usuario usuarioACompartir)
        {
            List<Usuario> listaConPrimerUsuario = new List<Usuario>();
            listaConPrimerUsuario.Add(usuarioACompartir);
            this.ObtenerContraseniasCompartidasPorMi().Add(duplaACompartir, listaConPrimerUsuario);
        }

        public void DejarDeCompartirContrasenia(Dupla_UsuarioContrasenia duplaADejarDeCompartir, Usuario usuarioAlQueDejoDeCompartir)
        {

            GestorContraseniasCompartidas gestorDelUsuarioADejarDeCompartir = usuarioAlQueDejoDeCompartir.GestorCompartirContrasenia;

            if (VerificarQueLaDuplaEsMia(duplaADejarDeCompartir))
                if (VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(duplaADejarDeCompartir, usuarioAlQueDejoDeCompartir))
                {
                    this.ObtenerContraseniasCompartidasPorMi()[duplaADejarDeCompartir].Remove(usuarioAlQueDejoDeCompartir);
                    if (VerificarQueNoEstoyCompartiendoLaContraseniaConAlguien(duplaADejarDeCompartir))
                        this.ObtenerContraseniasCompartidasPorMi().Remove(duplaADejarDeCompartir);
                    gestorDelUsuarioADejarDeCompartir.ObtenerContraseniasCompartidasConmigo()[duenio].Remove(duplaADejarDeCompartir);
                    if (gestorDelUsuarioADejarDeCompartir.ObtenerContraseniasCompartidasConmigo()[duenio].Count == 0)
                        gestorDelUsuarioADejarDeCompartir.ObtenerContraseniasCompartidasConmigo().Remove(duenio);
                }
                else
                {
                    throw new Exepcion_InvalidUsuarioData("Esta contraseña no ha sido compartida " +
                        "anteriormente con el usuario" + usuarioAlQueDejoDeCompartir.Nombre);
                }
            else
                throw new Exepcion_InvalidUsuarioData("No existe una contraseña asociada a " +
                    duplaADejarDeCompartir.Contrasenia + "para este usuario");
        }

        public bool VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(Dupla_UsuarioContrasenia dupla,
            Usuario usuario)
        {
            if (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla))
                return (this.ObtenerContraseniasCompartidasPorMi()[dupla].Contains(usuario));
            else
                return false;
        }

        public bool VerificarQueNoEstoyCompartiendoLaContraseniaConAlguien(Dupla_UsuarioContrasenia dupla)
        {
            return (this.ObtenerContraseniasCompartidasPorMi()[dupla].Count == 0);
        }

        public List<string> ConvertirContraseñasCompartidasPorMiAListaString(Dictionary<Dupla_UsuarioContrasenia,
            List<Usuario>> contrasenias)
        {
            List<string> resultado = new List<string>();

            foreach (var iterador in contrasenias)
                resultado.Add(iterador.Key.ToString());

            return resultado;
        }

        public List<string> ConvertirContraseñasCompartidasConmigoAListaString(Dictionary<Usuario,
            List<Dupla_UsuarioContrasenia>> contrasenias)
        {
            List<string> resultado = new List<string>();

            foreach (var iterador in contrasenias)
                foreach (var iteradorDuplas in iterador.Value)
                    resultado.Add(iteradorDuplas.ToString());

            return resultado;
        }

        public Dictionary<Dupla_UsuarioContrasenia, List<Usuario>> ObtenerContraseniasCompartidasPorMi()
        {
            return this.contraseniasCompartidasPorMi;
        }

        public Dictionary<Usuario, List<Dupla_UsuarioContrasenia>> ObtenerContraseniasCompartidasConmigo()
        {
            return this.contraseniasCompartidasConmigo;
        }
    }
}
