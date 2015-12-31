--Menu Inserts
	--Perfil del empleado
	insert into dbo.MenuSet values('Perfil del empleado','#','fa fa-user fa-fw',null);
		insert into dbo.MenuSet values('Consultar datos de empleado','#/consultardatosempleado',null,'Perfil del empleado');
		insert into dbo.MenuSet values('Actualizar datos personales','#/actualizardatospersonales',null,'Perfil del empleado');
		insert into dbo.MenuSet values('Actualizar datos profesionales','#','','Perfil del empleado');
			insert into dbo.MenuSet values('Cursos','#/actualizardatosprofesionales?action=cursos',null,'Actualizar datos profesionales');
			insert into dbo.MenuSet values('Certificaciones','#/actualizardatosprofesionales?action=certificaciones',null,'Actualizar datos profesionales');
			insert into dbo.MenuSet values('Estudios','#/actualizardatosprofesionales?action=estudios',null,'Actualizar datos profesionales');
			insert into dbo.MenuSet values('Experiencia laboral','#/actualizardatosprofesionales?action=exp',null,'Actualizar datos profesionales');
			insert into dbo.MenuSet values('Conocimientos','#/actualizardatosprofesionales?action=conocimientos',null,'Actualizar datos profesionales');
	--Gestion de control de vacaciones
	insert into dbo.MenuSet values('Gestion de control .de vacaciones','#','fa fa-sun-o fa-fw',null);
		insert into dbo.MenuSet values('Solicitar vacaciones','#/solicitatvacaciones',null,'Gestion de control .de vacaciones');
		insert into dbo.MenuSet values('Ver historial de solicitudes de vacaciones','#/historialvacaciones',null,'Gestion de control .de vacaciones');
	--Pagos	
		insert into dbo.MenuSet values('Pagos','#','fa fa-money fa-fw',null);
			insert into dbo.MenuSet values('Ver historial de pagos','#/historialpagos',null,'Pagos');
	--Documentos
		insert into dbo.MenuSet values('Documentos','#/generardocumentos','fa fa-files-o fa-fw',null);
		
		