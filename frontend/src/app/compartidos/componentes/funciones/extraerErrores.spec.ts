import { extraerErrores } from "./extraerErrores";

describe('extraerErrores', () =>{
    it('debe devolvver un array vacio si el objeto no tiene errores', () => {

        //Preparacion
        const input = {error: {errors:{}}};

        //Prueba
        const resultado = extraerErrores(input);

        //Verificacion
        expect(resultado).toEqual([]);
    })
})

describe('extraerErrores', () =>{
    it('Debe extraer correctamente los mensajes de error con sus campos', () => {

        //Preparacion
        const input = {error: {errors:{
            nombre: ['es obligatorio', 'primera letra debe ser mayuscula'],
            email: ['no es un email valido']
        }}};

        //Prueba
        const resultado = extraerErrores(input);

        //Verificacion
        expect(resultado).toEqual([
            'nombre: es obligatorio',
            'nombre: primera letra debe ser mayuscula',
            'email: no es un email valido'
        ]);
    })
})