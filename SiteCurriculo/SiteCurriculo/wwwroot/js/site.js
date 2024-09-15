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

function validarCPF(cpf) {
    cpf = cpf.replace(/[^\d]/g, '');
    return cpf.length === 11 && !isNaN(cpf);
}

function validarTelefone(telefone) {
    telefone = telefone.replace(/[^\d]/g, '');
    return telefone.length === 11 && !isNaN(telefone);
}

document.addEventListener('DOMContentLoaded', function () {
    document.querySelector('form').addEventListener('submit', function (event) {
        let valido = true;

        const formacaoAcademica = document.getElementById('formacao_academica').value;
        const experienciaProfissional = document.getElementById('experiencia_profissional').value;
        const idiomas = document.getElementById('idiomas').value;
        const cpf = document.getElementById('cpf').value;
        const telefone = document.getElementById('telefone').value;

        // Exemplo de limites (ajuste conforme necessário)
        const limiteFormacaoAcademica = 5;
        const limiteExperienciaProfissional = 10;
        const limiteIdiomas = 5;

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

        if (!validarCPF(cpf)) {
            Swal.fire({
                icon: 'error',
                title: 'CPF Inválido',
                text: 'O CPF fornecido é inválido.'
            });
            valido = false;
        }

        if (!validarTelefone(telefone)) {
            Swal.fire({
                icon: 'error',
                title: 'Telefone Inválido',
                text: 'O número de telefone fornecido é inválido.'
            });
            valido = false;
        }

        if (valido) {
            Swal.fire({
                icon: 'success',
                title: 'Sucesso!',
                text: 'Os dados foram salvos com sucesso!',
                confirmButtonText: 'OK',
                preConfirm: () => {
                    document.querySelector('form').submit();
                }
            });

            event.preventDefault();
        } else {
            event.preventDefault();
        }
    });
});
