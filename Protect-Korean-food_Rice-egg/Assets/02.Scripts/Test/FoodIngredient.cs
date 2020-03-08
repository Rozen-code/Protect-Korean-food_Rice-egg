using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodIngredient : MonoBehaviour
{
    // FIT(Food Ingredient Type)

    public enum RunFIT // 1
    {
        ONION,
        GREEN_ONION,
        PEPPER,
        SESAME_SEED
    }

    public enum RunAwayFIT // 2
    {
        BEEF,
        EGG,
        PORK,
        CHICKEN
    }

    public enum ClimbingFIT // 3 
    {
        SHIITAKE_MUSHROOMS,
        BRACKEN,
        BELLFLOWER,
        GINSENG
    }
    public enum HitTheMarkFIT // 4
    {
        JUJUBE,
        CHESTNUT,
        PEAR,
        HONEY
    }
    public enum FlipItFIT // 5
    {
        BEAN,
        GARLIC,
        GINGER,
        TARO
    }
    public enum GetItFIT // 6
    {
        CHINESE_CABBAGE,
        CUCUMBER,
        CORN,
        RADISH
    }
    public enum CatchItFIT // 7
    {
        RICE,
        BUCKWHEAT,
        FLOUR,
        BEAN_SPROUTS
    }
    public enum HitTheTargetFIT // 8
    {
        CARROT,
        POTATO,
        SPINACH
    }

    public GetItFIT getItFIT;

    private void Awake()
    {
        //if 게임모드가 겟잇핏을 필요로함

    }
}
