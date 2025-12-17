/*Problem 1*/
select p.product_name , s.year , s.price
from sales s
inner join product p 
on s.product_id = p.product_id;

/*Problem 2*/
select v.Customer_id , count(*) As count_no_trans
from Visits v
left join transactions t
 on v.visit_id = t.visit_id
where t.visit_id is Null
group by v.customer_id;

/*Problem 3*/
select EmployeeUNI.unique_id , Employees.name
from Employees
left join EmployeeUNI
on Employees.id = EmployeeUNI.id;

/*Problem 4*/
select W1.id
from Weather W1
inner join Weather W2
On DATEDIFF(W1.recordDate, W2.recordDate) = 1
Where W1.temperature > W2.temperature;

/*Problem 5*/
select e.emp_id, e.emp_name, IsNull(d.dept_name, 'Unassigned') As dept_name
From Employees e
Left join Departments d
On e.dept_id = d.dept_id;


/*Problem 6*/