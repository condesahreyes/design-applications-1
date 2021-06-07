using System.Collections.Generic;

namespace OblDiseño1.Entidades
{
    public class GestorContraseniasCompartidas
    {
        public Usuario duenio { get; set; }

        private Dictionary<Usuario, List<Credencial>> contraseniasCompartidasConmigo;
        private Dictionary<Credencial, List<Usuario>> contraseniasCompartidasPorMi;

        public GestorContraseniasCompartidas(Usuario usuario)
        {
            this.duenio = usuario;
            this.contraseniasCompartidasConmigo = new Dictionary<Usuario, List<Credencial>>();
            this.contraseniasCompartidasPorMi = new Dictionary<Credencial, List<Usuario>>();
        }

        private void CompartirContraseniaAUsuario(Credencial credencialACompartir, Usuario usuarioACompartir)
        {
            GestorContraseniasCompartidas gestorACompartir = usuarioACompartir.GestorCompartirContrasenia;
            if (gestorACompartir.VerificarQueElUsuarioMeEstaCompartiendoAlgunaContrasenia(duenio))
                gestorACompartir.ObtenerContraseniasCompartidasConmigo()[duenio].Add(credencialACompartir);
            else
                gestorACompartir.MeCompartenLaContraseniaPorPrimeraVez(duenio, credencialACompartir);
        }

        public void funcionCompartir(Credencial credencialACompartir, Usuario usuarioACompartir)
        {
            if (VerificarQueLaDuplaEsMia(credencialACompartir))
            {
                if (VerificarQueYaSeCompartioLaContraseniaConElUsuario(credencialACompartir, usuarioACompartir))
                    throw new ExepcionInvalidUsuarioData("Ya se compartio esta contraseña con el usuario" +
                        usuarioACompartir.Nombre);
                else
                {
                    GuardarLaContraseniaACompartir(credencialACompartir, usuarioACompartir);
                    CompartirContraseniaAUsuario(credencialACompartir, usuarioACompartir);
                }
            }
            else
                    throw new ExepcionInvalidUsuarioData("No existe una contraseña asociada a " +
                    credencialACompartir.Contraseña.Contrasenia + "para este usuario");

        }

        private void GuardarLaContraseniaACompartir(Credencial credencialACompartir, Usuario usuarioACompartir)
        {
            if (VerificarQueEstoyCompartiendoLaContraseniaConAlguien(credencialACompartir))
                this.ObtenerContraseniasCompartidasPorMi()[credencialACompartir].Add(usuarioACompartir);
            else
                CompartirContraseniaPorPrimeraVez(credencialACompartir, usuarioACompartir);
        }

        public void MeCompartenLaContraseniaPorPrimeraVez(Usuario usuarioQueMeComparte, Credencial credencialQueMeComparte)
        {
            List<Credencial> listaConPrimerDupla = new List<Credencial>();
            listaConPrimerDupla.Add(credencialQueMeComparte);
            this.ObtenerContraseniasCompartidasConmigo().Add(usuarioQueMeComparte, listaConPrimerDupla);
        }

        public bool VerificarQueElUsuarioMeEstaCompartiendoAlgunaContrasenia(Usuario usuario)
        {
            return (this.ObtenerContraseniasCompartidasConmigo().ContainsKey(usuario));
        }

        public bool VerificarQueLaDuplaEsMia(Credencial dupla)
        {
            return duenio.ObtenerCredenciales().Contains(dupla);
        }

        public bool VerificarQueYaSeCompartioLaContraseniaConElUsuario(Credencial credencial, Usuario usuario)
        {
            return (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(credencial) &&
                    this.ObtenerContraseniasCompartidasPorMi()[credencial].Contains(usuario));
        }

        public bool VerificarQueEstoyCompartiendoLaContraseniaConAlguien(Credencial dupla)
        {
            return (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(dupla));
        }

        public void CompartirContraseniaPorPrimeraVez(Credencial credencialACompartir, Usuario usuarioACompartir)
        {
            List<Usuario> listaConPrimerUsuario = new List<Usuario>();
            listaConPrimerUsuario.Add(usuarioACompartir);
            this.ObtenerContraseniasCompartidasPorMi().Add(credencialACompartir, listaConPrimerUsuario);
        }

        public void DejarDeCompartirContrasenia(Credencial credencialADejarDeCompartir, Usuario usuarioAlQueDejoDeCompartir)
        {

            GestorContraseniasCompartidas gestorDelUsuarioADejarDeCompartir = usuarioAlQueDejoDeCompartir.GestorCompartirContrasenia;

            if (VerificarQueLaDuplaEsMia(credencialADejarDeCompartir))
                if (VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(credencialADejarDeCompartir, usuarioAlQueDejoDeCompartir))
                {
                    this.ObtenerContraseniasCompartidasPorMi()[credencialADejarDeCompartir].Remove(usuarioAlQueDejoDeCompartir);
                    if (VerificarQueNoEstoyCompartiendoLaContraseniaConAlguien(credencialADejarDeCompartir))
                        this.ObtenerContraseniasCompartidasPorMi().Remove(credencialADejarDeCompartir);
                    gestorDelUsuarioADejarDeCompartir.ObtenerContraseniasCompartidasConmigo()[duenio].Remove(credencialADejarDeCompartir);
                    if (gestorDelUsuarioADejarDeCompartir.ObtenerContraseniasCompartidasConmigo()[duenio].Count == 0)
                        gestorDelUsuarioADejarDeCompartir.ObtenerContraseniasCompartidasConmigo().Remove(duenio);
                }
                else
                {
                    throw new ExepcionInvalidUsuarioData("Esta contraseña no ha sido compartida " +
                        "anteriormente con el usuario" + usuarioAlQueDejoDeCompartir.Nombre);
                }
            else
                    throw new ExepcionInvalidUsuarioData("No existe una contraseña asociada a " +
                    credencialADejarDeCompartir.Contraseña.Contrasenia + "para este usuario");

        }

        public bool VerificarQueEstaSiendoCompartidaLaContraseniaConElUsuario(Credencial credencial,
            Usuario usuario)
        {
            if (this.ObtenerContraseniasCompartidasPorMi().ContainsKey(credencial))
                return (this.ObtenerContraseniasCompartidasPorMi()[credencial].Contains(usuario));
            else
                return false;
        }

        public bool VerificarQueNoEstoyCompartiendoLaContraseniaConAlguien(Credencial credencial)
        {
            return (this.ObtenerContraseniasCompartidasPorMi()[credencial].Count == 0);
        }

        public List<string> ConvertirContraseñasCompartidasPorMiAListaString(Dictionary<Credencial,
            List<Usuario>> contrasenias)
        {
            List<string> resultado = new List<string>();

            foreach (var iterador in contrasenias)
                resultado.Add(iterador.Key.ToString());

            return resultado;
        }

        public List<string> ConvertirContraseñasCompartidasConmigoAListaString(Dictionary<Usuario,
            List<Credencial>> contrasenias)
        {
            List<string> resultado = new List<string>();

            foreach (var iterador in contrasenias)
                foreach (var iteradorDuplas in iterador.Value)
                    resultado.Add(iteradorDuplas.ToString());

            return resultado;
        }

        public Dictionary<Credencial, List<Usuario>> ObtenerContraseniasCompartidasPorMi()
        {
            return this.contraseniasCompartidasPorMi;
        }

        public Dictionary<Usuario, List<Credencial>> ObtenerContraseniasCompartidasConmigo()
        {
            return this.contraseniasCompartidasConmigo;
        }
    }
}
