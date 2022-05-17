var ingredientes = ['Farinha', 'Leite', 'Açúcar', 'Ovo'];
var ingredientesCoversao = [0.5, 1, 0.8, 0.75];
var ingredientesQtd = [1,2.5,3,2.2];

for(var i=0; i < ingredientes.length; i++){
    var option = document.createElement('option');
    option.value = i;
    option.text = ingredientes[i];
    document.getElementById('ingrediente').appendChild(option);
}

var unidades = ['gramas', 'mililitros', 'xícaras (240ml)', 'colheres de sopa (15ml)', 'colheres de chá (5ml)'];
var unidadesConversao = [0, 1, 240, 15, 5];

function converter(){
    var ingrediente = parseInt(
        document.getElementById('ingrediente').value-1
    );
    console.log(ingredientes[ingrediente]);

    var regra = ingredientesCoversao[ingrediente];

    var quantidadeEntrada = parseInt(
        document.getElementById('quantidade_entrada').value
    );

    console.log(quantidadeEntrada);

    var unidadeEntrada = parseInt(
        document.getElementById('unidade_entrada').value-1
    );

    console.log(unidades[unidadeEntrada]);

    var unidadeSaida = parseInt(
        document.getElementById('unidade_saida').value-1
    );

    console.log(unidades[unidadeSaida]);

    var quantidadeSaida = quantidadeEntrada;

    if(unidadesConversao[unidadeEntrada] == 0){
        quantidadeSaida *= (1/regra); // converter de g para ml
    } else {
        quantidadeSaida *= unidadesConversao[unidadeEntrada];
        //quantidade total em ml
    }

    if(unidadesConversao[unidadeSaida] == 0){
        quantidadeSaida *= regra;
    } else {
        quantidadeSaida /= unidadesConversao[unidadeSaida];
    }

    quantidadeSaida = formatar(
        quantidadeSaida,
        unidadesConversao[unidadeSaida],
        unidades[unidadeSaida]
    );

    document.getElementById('quantidade_saida').value = quantidadeSaida;



}

function formatar(resultado, ml, descricao) {
    var formatado;
    if (ml > 1) {
        var resto = resultado % 1;
        if (resto == 0 || resto > 0.75) {
            return Math.round(resultado) + " " + descricao;
        }
        resultado -= resto;
        if (resto <= 0.25) {
            formatado = '1/4';
        }
        else if (resto <= 0.3334) {
            formatado = '1/3';
        }
        else if (resto <= 0.5) {
            formatado = '1/2';
        }
        else if (resto <= 0.6667) {
            formatado = '2/3';
        }
        else if (resto <= 0.75) {
            formatado = '3/4';
        }
        if (resultado > 0)
            return resultado + " " + formatado + " " + descricao;
        else
            return formatado + " " + descricao;
    }
    return resultado + " " + descricao;
};