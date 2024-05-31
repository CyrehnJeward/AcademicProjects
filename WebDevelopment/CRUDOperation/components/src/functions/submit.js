$(document).ready(function () {
  $("#tableData").html(display());

  // Submit handler for the form with ID "myForm"
  $("#myForm").submit(function (e) {
    // Prevent default form submission to avoid page refresh
    e.preventDefault();

    // Get form field values
    let myData = {
      fname: $("#fname").val(),
      lname: $("#lname").val(),
      mn: $("#mn").val(),
      email: $("#email").val(),
      pw: $("#pw").val(),
      ut: $("#ut").val(),
    };

    // const result = displays.post("insert", myData);
    displays
      .post("insert", myData)
      .then((result) => {
        $("#statusQuery").html(result);
        resetForm();
        display();
      })
      .catch((error) => {
        $("#response").html(
          "Error: " + error + "  TextStatus" + textStatus + ", " + errorThrown
        );
      });
  });

  $("#tableData").on("click", "#btnEdit", function () {
    let id = $(this).attr("data-sid");
    $("#statusQuery").html(`This is the selected ID: ${id}`);
    console.log(`This is Edit ${id}`);
  });

  $("#tableData").on("click", "#btnRemove", function () {
    let id = $(this).attr("data-sid");
    deletes(id);
  });
});

const displays = new View();

const display = () => {
  displays
    .get("retrieve")
    .then((response) => {
      const table = $("#tableData");
      if (response) {
        if (Array.isArray(response)) {
          // Check if response is an array of rows
          let tableHeader = `
      <tr>
      <th>FirstName</th>
      <th>LastName</th>
      <th>Mobile Number</th>
      <th>Email</th>
      <th>UserType</th>
      <th>Edit</th>
      <th>Remove</th>
      </tr>
      `;

          table.html(tableHeader);
          // table.html(""); // Clear existing content before adding new data
          for (let i = 0; i < response.length; i++) {
            // Build HTML for each row using template literals (optional but recommended)
            let tableRow = `
        <tr>
        <td>${response[i].FirstName}</td>
        <td>${response[i].LastName}</td>
        <td>${response[i].MobileNumber}</td>
        <td>${response[i].Email}</td>
        <td>${response[i].UserType === 0 ? "Employee" : "Customer"}</td>
        <td>
          <div id="btnEdit" data-sid=${
            response[i].student_ID
          } class="container-contents-display-td-edit">Edit</div>
        </td>
        <td>
          <div id="btnRemove" data-sid=${
            response[i].student_ID
          } class="container-contents-display-td-remove">Remove</div>
        </td>
        </tr>
    `;
            // Set the HTML content of "tableData" with the current row
            table.append(tableRow); // Append each row to the table
          }
        } else {
          console.warn("Unexpected response format: Not an array");
        }
      } else {
        console.info("The database is empty");
      }
    })
    .catch((error) => {
      console.error("Error parsing response:", error);
      $("#response").html("Error: Could not process response data.");
    });
};

const deletes = (ID) => {
  let myData = {
    ID: ID,
  };

  displays
    .post("delete", myData)
    .then((result) => {
      display();
      $("#statusQuery").html(result);
    })
    .catch((error) => {
      $("#response").html(
        "Error: " + error + "  TextStatus" + textStatus + ", " + errorThrown
      );
    });
};

const resetForm = () => {
  $("#fname").val("");
  $("#lname").val("");
  $("#mn").val("");
  $("#email").val("");
  $("#pw").val("");
  $("#ut").val(0);
};
