const tblBlog = "Tbl_Blog";
let _tblID = "";
runBlog();

function runBlog() {
  Notiflix.Notify.init({
    position: "center-top",
    timeout: 2000,
    cssAnimation: true,
    cssAnimationDuration: 400,
    cssAnimationStyle: "fade",
    // useIcon: true,
    useFontAwesome: true,
    fontAwesomeIconStyle: "basic",
    fontAwesomeIconSize: "34px",
    success: {
      background: "#32c682",
      textColor: "#fff",
      fontAwesomeIconColor: "#fff",
      notiflixIconColor: "#fff",
    },
    info: {
      background: "#26c0d3",
      textColor: "#fff",
      fontAwesomeIconColor: "#fff",
      notiflixIconColor: "#fff",
      fontAwesomeClassName: "fas fa-check-circle",
    },
    failure: {
      fontAwesomeIconColor: "#fff",
      notiflixIconColor: "#fff",
    },
  });
  Notiflix.Confirm.init({
    titleColor:"red",
    messageColor: "black",
    messageFontSize: "14px",
    buttonsFontSize: "15px",
    buttonsMaxLength: 34,
    okButtonColor: "#fff",
    okButtonBackground: "red",
  });
  readBlog();
  //createBlog('title','author','content');
  //editBlog('5247d811-e96c-4968-bbcd-d7b81325fdb5');
  //readBlog();
  //deleteBlog('5247d811-e96c-4968-bbcd-d7b81325fdb5');
  //updateBlog('5c648609-a759-4a79-b795-1b7d7f7f31f9',"Holaa","HeeHa","Hakhak");
}
function readBlog() {
  $("#title").focus();
  $("#tabledata").html("");
  let lstblogs = getBlog();
  let htmlRows = "";
  for (let i = 0; i < lstblogs.length; i++) {
    const item = lstblogs[i];
    htmlRows += `<tr>
                        <th scope='row'>${i + 1}</th>
                        <td>${item.Title}</td>
                        <td>${item.Author}</td>
                        <td>${item.Content}</td>
                        <td style="text-align:center;">
                            <button class="btn btn-secondary" type="submit" onclick="editBlog('${
                              item.Id
                            }')"><i class="fa fa-pencil"></i> Edit</button>
                            <button class="btn btn-danger px-2" type="submit" onclick="deleteBlog('${
                              item.Id
                            }')"><i class="fa fa-trash"></i> Delete</button>
                        </td>
                     </tr>`;
  }
  $("#tabledata").html(htmlRows);
}
function createBlog(title, author, content) {
  let lstblogs = getBlog();
  //console.log(lstblogs);
  const blog = {
    Id: uuidv4(),
    Title: title,
    Author: author,
    Content: content,
  };
  lstblogs.push(blog);
  Notiflix.Notify.success("Successfully Added");
  //alert("Successfully Updated");
  //sweetAddorUpdate("A new blog is successfully added!");
  //lstblogs.push(blog);
  setLocalStorage(lstblogs);
  readBlog();
}
function editBlog(id) {
  let lstblogs = getBlog();
  lstblogs = lstblogs.filter((x) => x.Id === id);
  if (lstblogs.length == 0) {
    console.log("No Data Found");
    return;
  }
  let item = lstblogs[0];
  $("#title").val(item.Title);
  $("#author").val(item.Author);
  $("#content").val(item.Content);
  _tblID = id;
}
function updateBlog(id, title, author, content) {
  let lstblogs = getBlog();
  let lst = lstblogs.filter((x) => x.Id === id);
  if (lst.length == 0) {
    console.log("No Data Found");
    return;
  }

  let index = lstblogs.findIndex((x) => x.Id === id);
  lstblogs[index] = {
    Id: id,
    Title: title,
    Author: author,
    Content: content,
  };
  setLocalStorage(lstblogs);
  Notiflix.Notify.info("Successfully Updated");
  //sweetAddorUpdate("The blog is successfully updated!")
  readBlog();
}
function deleteBlog(id) {
  let lstblogs = getBlog();
  //let lst=lstblogs.filter(x=>x.Id === id);
  // if(lst.length==0)
  // {
  //     console.log("No Data Found");
  //     return;
  // }

  // Swal.fire({
  //     title: "Are you sure to delete this item?",
  //     //text: "You won't be able to revert this!",
  //     icon: "warning",
  //     showCancelButton: true,
  //     confirmButtonColor: "#3085d6",
  //     cancelButtonColor: "#d33",
  //     confirmButtonText: "Yes, delete it!"
  //   }).then((result) => {
  //     if (result.isConfirmed) {
  //       Swal.fire({
  //         title: "Deleted!",
  //         text: "This item has been deleted.",
  //         icon: "success"
  //       });
  Notiflix.Confirm.show(
    "Deleting Confirmation",
    "Are you sure to delete this blog?",
    "Confirm",
    "Cancel",
    function okCb() {
      lstblogs = lstblogs.filter((x) => x.Id !== id);
      Notiflix.Notify.failure("Successfully Deleted");
      setLocalStorage(lstblogs);
      readBlog();
    },
    // function cancelCb() {
    //     readBlog();
    // }
  );

  //readBlog();
  //     }
  //   });
}
function uuidv4() {
  return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, (c) =>
    (
      c ^
      (crypto.getRandomValues(new Uint8Array(1))[0] & (15 >> (c / 4)))
    ).toString(16)
  );
}
function getBlog() {
  let lstblogs = localStorage.getItem(tblBlog);
  return lstblogs ? JSON.parse(lstblogs) : [];
}
function setLocalStorage(blog) {
  let jsonBlog = JSON.stringify(blog);
  localStorage.setItem(tblBlog, jsonBlog);
}

$("#btnSave").click(function () {
  const title = $("#title").val();
  const author = $("#author").val();
  const content = $("#content").val();

  if (_tblID == "") {
    createBlog(title, author, content);
    //alert("New Blog is added successfully");
    //sweetAddorUpdate("New Blog is added successfully");
  } else {
    updateBlog(_tblID, title, author, content);
    // alert("Blog is Updated Successfully");
    //sweetAddorUpdate("The Blog is updated successfully");
    _tblID = "";
  }
  $("#title").val("");
  $("#author").val("");
  $("#content").val("");
  //$('#title').focus();
  readBlog();
});
// function sweetAddorUpdate(message)
// {
//     //event.preventDefault();
//     Swal.fire({
//         position: "middle",
//         icon: "success",
//         title: message,
//         showConfirmButton: false,
//         timer: 5000
//       });
// }
