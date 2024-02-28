const tblBlog='Tbl_Blog';
let _tblID='';
runBlog();
function runBlog(){
    readBlog();
    //createBlog('title','author','content');
    //editBlog('5247d811-e96c-4968-bbcd-d7b81325fdb5');
    //readBlog();
    //deleteBlog('5247d811-e96c-4968-bbcd-d7b81325fdb5');
    //updateBlog('5c648609-a759-4a79-b795-1b7d7f7f31f9',"Holaa","HeeHa","Hakhak");
}
function readBlog(){
    $('#tabledata').html('');
    let lstblogs = getBlog();
    let htmlRows = '';
    for(let i=0; i<lstblogs.length; i++)
    {
        const item=lstblogs[i];
        htmlRows += `<tr>
                        <th scope='row'>${i+1}</th>
                        <td>${item.Title}</td>
                        <td>${item.Author}</td>
                        <td>${item.Content}</td>
                        <td>
                            <button class="btn btn-warning" type="submit" onclick="editBlog('${item.Id}')"><i class="fa fa-pencil"></i> Edit</button>
                            <button class="btn btn-danger px-2" type="submit" onclick="deleteBlog('${item.Id}')"><i class="fa fa-trash"></i> Delete</button>
                        </td>
                     </tr>`
    }
    $('#tabledata').html(htmlRows);
}
function createBlog(title, author, content){
    let lstblogs = getBlog();
    console.log(lstblogs);
    const blog = {
        Id: uuidv4(),
        Title:title,
        Author:author,
        Content:content
    };
    lstblogs.push(blog);
    setLocalStorage(lstblogs);
}
function editBlog(id){
    let lstblogs = getBlog();
    lstblogs = lstblogs.filter(x=>x.Id === id);
    if(lstblogs.length==0)
    {
        console.log("No Data Found");
        return;
    }
    let item=lstblogs[0];
    $('#title').val(item.Title);
    $('#author').val(item.Author);
    $('#content').val(item.Content);
    _tblID=id;
}
function updateBlog(id,title,author,content){
    let lstblogs = getBlog();
    let lst=lstblogs.filter(x=>x.Id === id);
   if(lst.length==0)
   {
    console.log("No Data Found");
    return;
   }
   let index=lstblogs.findIndex(x=>x.Id === id);
   lstblogs[index] = {
    Id : id,
    Title : title,
    Author : author,
    Content : content
   };
   setLocalStorage(lstblogs);
}
function deleteBlog(id){
    let lstblogs = getBlog();
    let lst=lstblogs.filter(x=>x.Id === id);
    if(lst.length==0)
    {
        console.log("No Data Found");
        return;
    }
    lstblogs = lstblogs.filter(x=>x.Id !== id);
    alert("Blog is deleted successfully");
    setLocalStorage(lstblogs);
    readBlog();
}
function uuidv4() {
    return "10000000-1000-4000-8000-100000000000".replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
  }
function getBlog() {
    let lstblogs = localStorage.getItem(tblBlog);
    return lstblogs ? JSON.parse(lstblogs) : [];
}
function setLocalStorage(blog){
    let jsonBlog=JSON.stringify(blog);
    localStorage.setItem(tblBlog, jsonBlog);
}

$('#btnSave').click(function(){
    const title = $('#title').val();
    const author = $('#author').val();
    const content = $('#content').val();
    if(_tblID=='')
    {
        createBlog(title, author, content);
        alert("New Blog is added successfully");
    }
    else{
        updateBlog(_tblID,title,author,content);
        alert("Blog is Updated Successfully");
        _tblID='';
    }
    
    $('#title').val('');
    $('#author').val('');
    $('#content').val('');
    $('#title').focus();
})