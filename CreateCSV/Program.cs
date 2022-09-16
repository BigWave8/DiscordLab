using System.Text;

var path = @"C:\Projects\Discord\csvFile.csv";
StringBuilder strb = new();
Random r = new();
for (int i = 1; i <= 3; i++)
{
    strb.AppendLine($"Server,#abc{i},abc{i}");
}
for (int i = 1; i <= 200; i++)
{
    strb.AppendLine($"User,#user{i},user{i},{r.Next(0,2)},{r.Next(0,2)},#for{r.Next(1,51)}");
}
for (int i = 1; i <= 50; i++)
{
    strb.AppendLine($"Chat,#for{i},chat{i},#abc{r.Next(1,4)}");
}
for (int i = 1; i <= 1000; i++)
{
    strb.AppendLine($"Message,#msg{i},Small Text{i}{i}{i},{new DateTime(r.Next(2000,2022),r.Next(1,12),r.Next(1,28))},#for{r.Next(1,51)},#user{r.Next(1,201)}");
}

File.WriteAllText(path, strb.ToString(), Encoding.UTF8);