db.clientes.insertMany([{nome:"Ana",compras:[{produto:"Mouse",valor:49.9}]},{nome:"João",compras:[{produto:"Teclado",valor:99.9}]}]);
db.clientes.find({nome:"Ana"});