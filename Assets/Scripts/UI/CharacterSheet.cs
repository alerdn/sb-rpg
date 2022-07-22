using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterSheet : MonoBehaviour
{
    [Header("Character Info")]
    [SerializeField] private TMP_Text characterName;
    [SerializeField] private TMP_Text characterClass;
    [SerializeField] private TMP_Text characterRace;
    [SerializeField] private TMP_Text characterLevel;

    [Header("Experience")]
    [SerializeField] private Image xpBar;

    [Header("Strength")]
    [SerializeField] private TMP_Text strModifier;
    [SerializeField] private TMP_Text strScore;
    [Header("Dexterity")]
    [SerializeField] private TMP_Text dexModifier;
    [SerializeField] private TMP_Text dexScore;
    [Header("Constitution")]
    [SerializeField] private TMP_Text constModifier;
    [SerializeField] private TMP_Text constScore;
    [Header("Intelligence")]
    [SerializeField] private TMP_Text intellModifier;
    [SerializeField] private TMP_Text intellScore;
    [Header("Wisdom")]
    [SerializeField] private TMP_Text wisModifier;
    [SerializeField] private TMP_Text wisScore;
    [Header("Charisma")]
    [SerializeField] private TMP_Text charModifier;
    [SerializeField] private TMP_Text charScore;

    [Header("Character Display")]
    [SerializeField] private Image _sprite;

    private Hero _hero;

    private void OnEnable()
    {
        UpdateUI();
    }

    private void Start()
    {
        _hero = HeroManager.Instance.Hero;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (_hero == null) return;

        // Infos
        characterName.text = _hero.Name;
        characterClass.text = _hero.Class.name;
        characterRace.text = _hero.Race.name;
        characterLevel.text = _hero.Level.ToString();

        // Experience
        xpBar.fillAmount =
            (_hero.ExperienceAmount - HeroManager.LevelDictonary[_hero.Level - 1]) * 100
            / (HeroManager.LevelDictonary[_hero.Level] - HeroManager.LevelDictonary[_hero.Level - 1]) 
            / 100f;

        // Attributes
        strModifier.text = _hero.AttributeModifier(_hero.Stats.Strength).ToString();
        strScore.text = _hero.Stats.Strength.ToString();

        dexModifier.text = _hero.AttributeModifier(_hero.Stats.Dexterity).ToString();
        dexScore.text = _hero.Stats.Dexterity.ToString();

        constModifier.text = _hero.AttributeModifier(_hero.Stats.Constitution).ToString();
        constScore.text = _hero.Stats.Constitution.ToString();

        intellModifier.text = _hero.AttributeModifier(_hero.Stats.Intelligence).ToString();
        intellScore.text = _hero.Stats.Intelligence.ToString();

        wisModifier.text = _hero.AttributeModifier(_hero.Stats.Wisdom).ToString();
        wisScore.text = _hero.Stats.Wisdom.ToString();

        charModifier.text = _hero.AttributeModifier(_hero.Stats.Charisma).ToString();
        charScore.text = _hero.Stats.Charisma.ToString();

        // Display
        _sprite.sprite = _hero.Sprite;
    }
}
