
    $(document).ready(function() {
        
        var accessToken = "";

        var showResponse = function(object) {
            $('#output').text(JSON.stringify(object, null, 4));
        };

        var getHeaders = function () {
            if (accessToken) {
                return { "Authorization": "Bearer " + accessToken };
            }
        };

        var getPatients = function () {
            var url = "http://localhost:44117/api/Patients";
            $.ajax(url,
            {
                type: "GET",
                headers: getHeaders()
            }).always(showResponse);
            return false;
            //$.get(url).always(showResponse);
        };
        

        var register = function() {
            var url = "/api/Account/Register";
            var data = $("#userData").serialize();
            $.post(url, data).always(showResponse);
            return false;
        };
        var saveSessionToken = function(data) {
            accessToken = data.access_token;
        };

        var login = function() {
            var url = "/Token";
            var data = $("#userData").serialize();
            data = data + "&grant_type=password";
            $.post(url, data)
                .success(saveSessionToken)
                .always(showResponse);
            return false;
        };

        
        $("#login").click(login);
        $("#register").click(register);
        $('#getPatients').click(getPatients);
    });
