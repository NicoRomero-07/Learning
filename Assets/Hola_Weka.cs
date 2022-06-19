using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using weka.classifiers.trees;
using weka.classifiers.evaluation;
using weka.core;
using java.io;
using java.lang;
using java.util;
using weka.classifiers.functions;
using weka.classifiers;

public class Hola_Weka : MonoBehaviour{
    private string estado = "Sin conocimiento";
    weka.core.Instances casosEntrenamiento;
    weka.classifiers.trees.M5P saberSacarCuadrado, saberSacarRaiz;

    void Start(){
        if (estado == "Sin conocimiento") StartCoroutine("Entrenamiento");
    }

    IEnumerator Entrenamiento(){
        casosEntrenamiento = new weka.core.Instances(new java.io.FileReader("Assets/Tabla_y_x2_vacia.arff"));

        //CONSTRUCCION DE CASOS DE ENTRENAMIENTO
        print("Construccion de casos (x, y) donde y = x*x, con pasos de x de 1%");

        float valorMaximoX = 60;
        for (float x = 0;    x < valorMaximoX;   x= x + 0.01f*valorMaximoX){  
                float y = x * x;
                Instance casoAdecidir = new Instance(casosEntrenamiento.numAttributes());
                casoAdecidir.setDataset(casosEntrenamiento);
                casoAdecidir.setValue(0, x);
                casoAdecidir.setValue(1, y);   
                casosEntrenamiento.add(casoAdecidir);
                yield return new WaitForSeconds(0.0f);
        }
        print("Se crearon " + casosEntrenamiento.numInstances()+" casos de entrenamiento");

        //APRENDIZAJE DE CONOCIMIENTO:  

        casosEntrenamiento.setClassIndex(1);  //Si la variable a aprender es Y (id=1), se aprende a sacar el cuadrado
        saberSacarCuadrado = new M5P();
        saberSacarCuadrado.buildClassifier(casosEntrenamiento);

        //casosEntrenamiento.setClassIndex(0);    //Si la variable a aprender es X (id=0), se aprende a sacar la raiz cuadrada
        //saberSacarRaiz = new M5P();
        //saberSacarRaiz.buildClassifier(casosEntrenamiento);
        print("Se aprendió un conocimiento con el algoritmo "+ saberSacarCuadrado.getClass().getCanonicalName());

        //EVALUACION DEL CONOCIMIENTO APRENDIDO: 
        Evaluation evaluador = new Evaluation(casosEntrenamiento);
        evaluador.crossValidateModel(saberSacarCuadrado, casosEntrenamiento, 10, new java.util.Random(1));
        print("El Error Absoluto Promedio durante el entrenamiento fue de " + evaluador.meanAbsoluteError());

        estado = "Con conocimiento";
    }

    float X_observado = 150.0f;
    void Update(){
        //Se ha observado que Y tiene el valor "Y_observado", este Update predice X.   

        if ((estado == "Con conocimiento") && (X_observado > 0)){
            Instance casoPrueba = new Instance(casosEntrenamiento.numAttributes());
            casoPrueba.setDataset(casosEntrenamiento);
            casoPrueba.setValue(0, X_observado);
            float prediccionY = (float)saberSacarCuadrado.classifyInstance(casoPrueba);
            print("En el caso particuar de número "+ X_observado+" el NPC estima que su cuadrado es "+ prediccionY+"   Error= " + ((X_observado*X_observado)-prediccionY));

            //El NPC actuará con base en su prediccion . Por ejemplo, ... rb.addForce ( F * prediccionX);

            X_observado = -1;  //Desactiva las predicciones
        }
    }
}
