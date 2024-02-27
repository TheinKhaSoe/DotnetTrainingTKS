const tblBlog='Tbl_Blog';
runBlog();
function runBlog(){
    //createBlog('title','author','content');
    //editBlog('5247d811-e96c-4968-bbcd-d7b81325fdb5');
    //readBlog();
    //deleteBlog('5247d811-e96c-4968-bbcd-d7b81325fdb5');
    //updateBlog('5c648609-a759-4a79-b795-1b7d7f7f31f9',"Holaa","HeeHa","Hakhak");
}
function readBlog(){
    let lstblogs = getBlog();
    for(let i=0; i<lstblogs.length; i++)
    {
        const item=lstblogs[i];
        console.log(item.Title);
        console.log(item.Author);
        console.log(item.Content);
    }
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
    console.log(lstblogs);
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
    setLocalStorage(lstblogs);
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