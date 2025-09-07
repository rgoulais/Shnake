#!/bin/bash

OUTPUT_FILE="Assets.cs"
ASSETS_DIR="Assets"

if [ ! -d "$ASSETS_DIR" ]; then
  echo "Erreur : Le dossier '$ASSETS_DIR' n'a pas été trouvé."
  echo "Veuillez lancer ce script depuis la racine de votre projet."
  exit 1
fi

echo "// Ce fichier est généré automatiquement
// Ne le modifiez pas manuellement !
namespace Shnake;

public enum Sprite
{" > $OUTPUT_FILE

find "$ASSETS_DIR" -type f \( -name "*.png" -o -name "*.jpg" -o -name "*.jpeg" \) | while read file; do
  BASENAME=$(basename "$file")
  ENUM_NAME="${BASENAME%.*}"
  echo "    $ENUM_NAME," >> $OUTPUT_FILE
done

echo "
}

public enum SoundEffect
{" >> $OUTPUT_FILE

find "$ASSETS_DIR" -type f \( -name "Ui*.ogg" \) | while read file; do
  BASENAME=$(basename "$file")
  ENUM_NAME="${BASENAME%.*}"
  echo "    $ENUM_NAME," >> $OUTPUT_FILE
done

echo "
}

public enum Musique
{" >> $OUTPUT_FILE

find "$ASSETS_DIR/" -type f \( -name "Music*.ogg" \) | while read file; do
  BASENAME=$(basename "$file")
  ENUM_NAME="${BASENAME%.*}"
  echo "    $ENUM_NAME," >> $OUTPUT_FILE
done

echo '
}

public static class AssetExtensions
{
    public static string GetPath(this Sprite sprite)
    {
        return "Assets/" + sprite.ToString() + ".png";
    }

    public static string GetPath(this SoundEffect sound)
    {
        return "Assets/" + sound.ToString() + ".ogg";
    }

    public static string GetPath(this Musique sound)
    {
        return "Assets/" + sound.ToString() + ".ogg";
    }
}' >> $OUTPUT_FILE

echo "Le fichier '$OUTPUT_FILE' a été généré avec succès."