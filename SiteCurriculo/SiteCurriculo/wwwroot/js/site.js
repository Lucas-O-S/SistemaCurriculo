function VerificarNumValores(limite, input, nomeCampo) {
    const valores = input.split(',').map(valor => valor.trim());
    if (valores.length > limite) {
        Swal.fire({
            icon: 'error',
            title: 'Limite de Valores',
            text: 'O campo ' + nomeCampo + ' aceita somente ' + limite + ' valores.'
        });
        return false;
    } else {
        return true;
    }
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('form').addEventListener('submit', function (event) {
        let valido = true;

        const formacaoAcademica = document.getElementById('formacao_academica').value;
        const experienciaProfissional = document.getElementById('experiencia_profissional').value;
        const idiomas = document.getElementById('idiomas').value;

        // Exemplo de limites (ajuste conforme necessário)
        const limiteFormacaoAcademica = 5; // Limite de valores para Formação Acadêmica
        const limiteExperienciaProfissional = 10; // Limite de valores para Experiência Profissional
        const limiteIdiomas = 5; // Limite de valores para Idiomas

        // Verifica os campos e impede o envio do formulário se algum campo for inválido
        if (!VerificarNumValores(limiteFormacaoAcademica, formacaoAcademica, 'Formação Acadêmica')) {
            valido = false;
        }
        if (!VerificarNumValores(limiteExperienciaProfissional, experienciaProfissional, 'Experiência Profissional')) {
            valido = false;
        }
        if (!VerificarNumValores(limiteIdiomas, idiomas, 'Idiomas')) {
            valido = false;
        }

        if (valido) {
            // Exibe a notificação de sucesso e aguarda a confirmação do usuário
            Swal.fire({
                icon: 'success',
                title: 'Sucesso!',
                text: 'Os dados foram salvos com sucesso!',
                confirmButtonText: 'OK',
                preConfirm: () => {
                    // Envia o formulário após o usuário clicar no botão 'OK'
                    document.querySelector('form').submit();
                }
            });

            event.preventDefault(); // Impede o envio imediato do formulário
        } else {
            event.preventDefault(); // Impede o envio do formulário se algum campo for inválido
        }
    });
});
