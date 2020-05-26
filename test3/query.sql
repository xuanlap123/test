select p.Name, Max(t.Total) as NumberOfSellingProducts
from product as p join (select od.ProductId, sum(od.Amount) as Total 
						from OrderDetail as od on p.Id == od.ProductId join Order as o on o.Id == od.OrderId 
						where o.Date >= startDate AND o.Date <= endDate;
						group by od.ProductId) as t on t.ProductId = p.Id;