using System;
using System.Collections;
using System.Collections.Generic;
using Comments.Level;
using Data.UnityObjects;
using Data.ValueObjects;
using Signals;
using Unity.VisualScripting;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private Transform levelHolder;
        [SerializeField] private byte totalLevelCount;

        private OnLevelLoaderCommand _levelLoaderCommand;
        private OnLevelDestroyerCommand _levelDestroyerCommand;

        private byte _currentLevel;
        private LevelData _levelData;


        private void Awake()
        {
           _levelData = GetLevelData();
            _currentLevel = GetActiveLevel();

            Init();
        }

        private void Init()
        {
           _levelLoaderCommand = new OnLevelLoaderCommand(levelHolder);
           _levelDestroyerCommand =  new OnLevelDestroyerCommand(levelHolder);
        }

        private byte GetActiveLevel()
        {
            return _currentLevel;
        }

        private LevelData GetLevelData()
        {
            return Resources.Load<CD_Level>("Data/CD_Level").LevelDatas[_currentLevel];
        }

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize += _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onClearActiveLevel += _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue += OnGetLevelValue;
            CoreGameSignals.Instance.onNextLevel += OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel += OnRestartLevel;
        }

        private byte OnGetLevelValue()
        {
            return _currentLevel;
        }

        private void OnNextLevel()
        {
            _currentLevel++;
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }

        private void OnRestartLevel()
        {
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onReset?.Invoke();
            CoreGameSignals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
        }

        private void UnSubscribeEvents()
        {
            CoreGameSignals.Instance.onLevelInitialize -= _levelLoaderCommand.Execute;
            CoreGameSignals.Instance.onClearActiveLevel -= _levelDestroyerCommand.Execute;
            CoreGameSignals.Instance.onGetLevelValue -= OnGetLevelValue;
            CoreGameSignals.Instance.onNextLevel -= OnNextLevel;
            CoreGameSignals.Instance.onRestartLevel -= OnRestartLevel;
        }

        private void OnDisable()
        {
            UnSubscribeEvents();
        }

        private void Start()
        {
            CoreGameSignals.Instance.onLevelInitialize?.Invoke((byte)(_currentLevel % totalLevelCount));
            CoreUISignals.Instance.onOpenPanel(Enums.UIPanelTypes.Start,1);
        }
    }
}
