class View {
  get = (fileDik) => {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `http://localhost/projects/VanillaProjects/components/src/API/${fileDik}.php`,
        method: "GET",
        dataType: "json",
        success: function (response) {
          resolve(response); // Resolve the promise with the response data
        },
        error: function (jqXHR, textStatus, errorThrown) {
          reject(new Error(`AJAX Error: ${textStatus}, ${errorThrown}`)); // Reject with an error object
        },
      });
    });
  };
  post = (fileDik, myData) => {
    return new Promise((resolve, reject) => {
      $.ajax({
        url: `http://localhost/projects/VanillaProjects/components/src/API/${fileDik}.php`, // Replace with the correct path to your script
        method: "POST",
        data: myData,
        success: function (response) {
          resolve(response);
        },
        error: function (jqXHR, textStatus, errorThrown) {
          // Handle errors (consider logging or displaying a user-friendly message)
          reject(new Error(`AJAX Error: ${textStatus}, ${errorThrown}`)); // Reject with an error object
        },
      });
    });
  };
}
