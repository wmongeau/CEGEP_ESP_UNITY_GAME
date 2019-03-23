using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainScript : MonoBehaviour
{

    const int NB_TRIANGLES_PAR_TUILE = 2;
    const int NB_SOMMETS_PAR_TRIANGLE = 3;
    const int COULEUR_MAX = 255;

    [SerializeField]
    Texture2D TextureCarte;

    Color[] PixelsCarte;
    Color[] PixelsHerbe;
    Color[] PixelsRoc;
    Color[] PixelsHerbeRoc;
    Texture2D TextureMixte;
    [SerializeField]  
    float HauteurMax; 



    [SerializeField]
    Texture2D TextureHerbe;

    [SerializeField]
    Texture2D TextureRoc;

    [SerializeField]    
    Vector2 Étendue = new Vector2();
    Vector2 Charpente;  

    Mesh Maillage;
    Vector3[] Sommets;  

    public Vector3 Origine;    // L'origine du vecteur est fixée de manière à ce que le triangle soit centrée au point (0, 0, 0) de l'espace virtuel
    Vector3 Delta;
    int NbColonnes;
    int NbRangées;
    int NbSommets;
    int NbTriangles;


    void Awake()
    {
        ChargerCarte();
        CalculerDonnéesDeBase();
        GénérerTriangles();
        GetComponent<MeshCollider>().sharedMesh = Maillage;
    }
    private void ChargerCarte()
    {
        Charpente = new Vector2(TextureCarte.width, TextureCarte.height);
        PixelsCarte = TextureCarte.GetPixels();
        PixelsHerbe = TextureHerbe.GetPixels();
        PixelsRoc = TextureRoc.GetPixels();
        TextureMixte = new Texture2D(TextureCarte.width, TextureCarte.height);
        PixelsHerbeRoc = new Color[PixelsCarte.Length];
    }
    private void CalculerDonnéesDeBase()
    {

        Étendue = Charpente;
        Origine = new Vector3(-Étendue.x / 2, -Étendue.y / 2 );
        NbColonnes = (int)Charpente.x - 1;
        NbRangées = (int)Charpente.y - 1;
        NbSommets = (NbColonnes + 1) * (NbRangées + 1);
        NbTriangles = NbColonnes * NB_TRIANGLES_PAR_TUILE * NbRangées;
        Delta = new Vector3(Étendue.x / NbColonnes, Étendue.y / NbRangées);
    }

    private void GénérerTriangles()
    {
        Maillage = new Mesh();
        GetComponent<MeshFilter>().mesh = Maillage;
        Maillage.name = "Surface";
        GénérerSommets();
        GénérerListeTriangles();
    }

    private void GénérerSommets()
    {
        int compteur = 0;
        Sommets = new Vector3[NbSommets];
        Vector2[] coordonnéesTexture = new Vector2[NbSommets];
        for (int i = 0; i <= NbRangées; i++)
        {
            for (int j = 0; j <= NbColonnes; j++)
            {
                Sommets[compteur] = new Vector3(Origine.x + Delta.x * j, PixelsCarte[compteur].b * HauteurMax, Origine.y + Delta.y * i);
                coordonnéesTexture[compteur] = new Vector2(-Étendue.x + (Delta.x * j / Étendue.x), -Étendue.y + (Delta.y * i / Étendue.y));
                PixelsHerbeRoc[compteur].b = PixelsHerbe[compteur].b * (1 + PixelsCarte[compteur].b) + PixelsRoc[compteur].b * -PixelsCarte[compteur].b;
                PixelsHerbeRoc[compteur].g = PixelsHerbe[compteur].g * (1 + PixelsCarte[compteur].g) + PixelsRoc[compteur].g * -PixelsCarte[compteur].g;
                PixelsHerbeRoc[compteur].r = PixelsHerbe[compteur].r * (1 + PixelsCarte[compteur].r) + PixelsRoc[compteur].r * -PixelsCarte[compteur].r;

                compteur++;
            }
        }
        TextureMixte.SetPixels(PixelsHerbeRoc);
        TextureMixte.Apply();
        GetComponent<MeshRenderer>().material.mainTexture = TextureMixte;

        Maillage.vertices = Sommets;
        Maillage.uv = coordonnéesTexture;
    }


    private void GénérerListeTriangles()
    {
        int[] triangles = new int[NbTriangles * NB_SOMMETS_PAR_TRIANGLE];
        int[] Pts = new int[4];
        int indice = 0;
        for (int i = 0; i < NbRangées; i++)
        {
            for (int j = 0; j < NbColonnes; j++)
            {
                Pts[0] = j + i * (NbColonnes + 1);
                Pts[1] = j + (i + 1) * (NbColonnes + 1);
                Pts[2] = Pts[0] + 1;
                Pts[3] = Pts[1] + 1;

                triangles[indice] = Pts[0];
                indice++;
                triangles[indice] = Pts[1];
                indice++;
                triangles[indice] = Pts[2];
                indice++;
                triangles[indice] = Pts[2];
                indice++;
                triangles[indice] = Pts[1];
                indice++;
                triangles[indice] = Pts[3];
                indice++;
            }
        }

        Maillage.triangles = triangles;
        Maillage.RecalculateNormals();
    }
    public Vector3 GetPointSpatial(int x, int y)
    {


        x = x - (int)Origine.x;
        y = y - (int)Origine.y;
        Vector3 vecteur = Sommets[y + x * (NbColonnes + 1)];
        return vecteur;



    }
}
