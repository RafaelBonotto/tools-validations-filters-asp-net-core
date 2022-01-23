

using System.Drawing;

namespace Colaboracao.Core
{
    public interface ITools
    {
        long jsonStringToLong(string numero);

        bool verificaArquivo(string arquivo);

        bool gravaImagem(string caminho, byte[] imagem, string nomeImagem);

        bool gravaImagemThumb(string caminho, byte[] imagem, string nomeImagem);
        bool gravaImagemThumbMini(string caminho, byte[] imagem, string nomeImagem);

        bool gravaImagemThumbVeryMini(string caminho, byte[] imagem, string nomeImagem);

        Image ResizeImage(Image imgToResize, Size destinationSize);

        bool gravaArquivo(string caminho, byte[] arquivo, string nomeArquivo);

        bool deletaImagem(string caminho, string nomeImagem);

        bool validaCnpj(string cnpj);

        bool validaCpf(string cpf);

        bool validaEmail(string email);
    }
}
