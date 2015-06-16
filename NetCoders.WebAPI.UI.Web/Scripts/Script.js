$(function () {
    $('#btnTesteWebAPI').on('click', function () {
        var $btn = $(this).button('loading');
        $.ajax({
            url: 'http://localhost:20304/api/Test',
            method: $('#selectMethod').val(),
            data: { 'Nome': 'Jean', 'Idade': 25 },
            statusCode: {
                404: function (data) {
                    $('#outputWebApiTeste').text('HTTP StatuCode: ' + data.statusText + '\r\n' + data.responseText);
                    $btn.button('reset');
                },
                406: function (data) {
                    $('#outputWebApiTeste').text('HTTP StatuCode: ' + data.statusText + '\r\n' + data.responseText);
                    $btn.button('reset');
                }
            },
            success: function (data) {
                $('#outputWebApiTeste').text(data);
                $btn.button('reset');
            }
        });
    });




    $('#btnVersionamentoWebAPI').on('click', function () {
        var $btn = $(this).button('loading');
        var versionApi = $('#selectMethodVersionamento').val();
        $.ajax({
            url: 'http://localhost:20304/Version/' + versionApi,
            method: 'GET',
            success: function (data) {
                $('#outputWebApiVersionamento').text(data);
                $btn.button('reset');
            }
        });
    });




    $('#btnGlobalizationAPI').on('click', function () {
        var $btn = $(this).button('loading');
        var headerGlobalization = $('#selectMethodGlobalization').val();
        $.ajax({
            url: 'http://localhost:20304/Translate/Get',
            headers:{'Accept-Language':headerGlobalization},
            method: 'GET',
            success: function (data) {
                $('#outputWebApiGlobalization').text(data);
                $btn.button('reset');
            }
        });
    });






    $('#btnAutenticacaoWebAPI').on('click', function () {
        var $btn = $(this).button('loading');
        var autenticationUser = btoa("jean:jean123");
        $.ajax({
            url: 'http://localhost:20304/Auth/Authentication',
            method: 'GET',
            headers: { 'Authorization': 'Basic ' + autenticationUser },
            statusCode: {
                406: function (data) {
                    $('#outputWebApiAutenticacao').text(data);
                    $btn.button('reset');
                }
            },
            success: function (data) {
                $('#outputWebApiAutenticacao').text(data);
                $btn.button('reset');
            }
        });
    });

})
