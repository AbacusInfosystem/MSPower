$(function () {

    $.ajax({
        url: "/web-app/get-about-us",

        data: { language: $("#hdfsessionLanguage").val() }

    }).done(function (data) {
        
        $("#pAboutUs").html(data.AboutUs.About_Us_Description);
    });

    $.ajax({
        url: "/web-app/get-news",

        data: { language: $("#hdfsessionLanguage").val() }

    }).done(function (data) {

        var html = "";

        if(data.NewsLetters.length > 0)
        {
            for(var i=0;i<data.NewsLetters.length; i++ )
            {
                 html += "<li>";
                 html += "<p style='color: #EE1C25'><strong>"+data.NewsLetters[i].NewsLetter_Title+"</strong></p>";
                 html += "<p>"+data.NewsLetters[i].NewsLetter_Description+"</p>";
                 html += "</li>";
            }
        }

        $("#ulLatestNews").html(html)
    });

    $.ajax({
        url: "/web-app/get-hot-jobs",

        data: { language: $("#hdfsessionLanguage").val() }

    }).done(function (data) {

        var html = "";

        if (data.Job_Openings.length > 0) {
            for (var i = 0; i < data.Job_Openings.length; i++) {
                html += "<li>";
                html += "<p style='color: #EE1C25'><strong>" + data.Job_Openings[i].Job_Title + "</strong></p>";
                html += "<p>" + data.Job_Openings[i].Job_Description + "</p>";
                html += "</li>";
            }
        }

        

        $("#ulHotJobs").html(html)
    });

    $.ajax({
        url: "/web-app/get-events",

        data: { language: $("#hdfsessionLanguage").val() }

    }).done(function (data) {

        var html = "";

        if (data.Events.length > 0) {
            for (var i = 0; i < data.Events.length; i++) {
                html += "<li>";
                html += "<p style='color: #EE1C25'><strong>" + data.Events[i].Event_Title + "</strong></p>";
                html += "<p>" + data.Events[i].Event_Description + "</p>";
                html += "</li>";
            }
        }

        $("#ulEvents").html(html)
    });

});