

select * from Product_Category_New pcn where  pcn.Product_Category_Id in (

select pc.Product_Category_Id from Product_Category_New pc where pc.Parent_Category_Id= pcn.Parent_Category_Id 
);