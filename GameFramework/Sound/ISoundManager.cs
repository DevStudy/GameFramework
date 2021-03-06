﻿//------------------------------------------------------------
// Game Framework v3.x
// Copyright © 2013-2017 Jiang Yin. All rights reserved.
// Homepage: http://gameframework.cn/
// Feedback: mailto:jiangyin@gameframework.cn
//------------------------------------------------------------

using GameFramework.Resource;
using System;

namespace GameFramework.Sound
{
    /// <summary>
    /// 声音管理器接口。
    /// </summary>
    public interface ISoundManager
    {
        /// <summary>
        /// 获取声音组数量。
        /// </summary>
        int SoundGroupCount
        {
            get;
        }

        /// <summary>
        /// 播放声音成功事件。
        /// </summary>
        event EventHandler<PlaySoundSuccessEventArgs> PlaySoundSuccess;

        /// <summary>
        /// 播放声音失败事件。
        /// </summary>
        event EventHandler<PlaySoundFailureEventArgs> PlaySoundFailure;

        /// <summary>
        /// 播放声音更新事件。
        /// </summary>
        event EventHandler<PlaySoundUpdateEventArgs> PlaySoundUpdate;

        /// <summary>
        /// 播放声音时加载依赖资源事件。
        /// </summary>
        event EventHandler<PlaySoundDependencyAssetEventArgs> PlaySoundDependencyAsset;

        /// <summary>
        /// 设置资源管理器。
        /// </summary>
        /// <param name="resourceManager">资源管理器。</param>
        void SetResourceManager(IResourceManager resourceManager);

        /// <summary>
        /// 设置声音辅助器。
        /// </summary>
        /// <param name="soundHelper">声音辅助器。</param>
        void SetSoundHelper(ISoundHelper soundHelper);

        /// <summary>
        /// 是否存在指定声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <returns>指定声音组是否存在。</returns>
        bool HasSoundGroup(string soundGroupName);

        /// <summary>
        /// 获取指定声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <returns>要获取的声音组。</returns>
        ISoundGroup GetSoundGroup(string soundGroupName);

        /// <summary>
        /// 获取所有声音组。
        /// </summary>
        /// <returns>所有声音组。</returns>
        ISoundGroup[] GetAllSoundGroups();

        /// <summary>
        /// 增加声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="soundGroupHelper">声音组辅助器。</param>
        /// <returns>是否增加声音组成功。</returns>
        bool AddSoundGroup(string soundGroupName, ISoundGroupHelper soundGroupHelper);

        /// <summary>
        /// 增加声音组。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="soundGroupAvoidBeingReplacedBySamePriority">声音组中的声音是否避免被同优先级声音替换。</param>
        /// <param name="soundGroupMute">声音组是否静音。</param>
        /// <param name="soundGroupVolume">声音组音量。</param>
        /// <param name="soundGroupHelper">声音组辅助器。</param>
        /// <returns>是否增加声音组成功。</returns>
        bool AddSoundGroup(string soundGroupName, bool soundGroupAvoidBeingReplacedBySamePriority, bool soundGroupMute, float soundGroupVolume, ISoundGroupHelper soundGroupHelper);

        /// <summary>
        /// 增加声音代理辅助器。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="soundAgentHelper">要增加的声音代理辅助器。</param>
        void AddSoundAgentHelper(string soundGroupName, ISoundAgentHelper soundAgentHelper);

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <returns>声音的序列编号。</returns>
        int PlaySound(string soundAssetName, string soundGroupName);

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="playSoundParams">播放声音参数。</param>
        /// <returns>声音的序列编号。</returns>
        int PlaySound(string soundAssetName, string soundGroupName, PlaySoundParams playSoundParams);

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>声音的序列编号。</returns>
        int PlaySound(string soundAssetName, string soundGroupName, object userData);

        /// <summary>
        /// 播放声音。
        /// </summary>
        /// <param name="soundAssetName">声音资源名称。</param>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="playSoundParams">播放声音参数。</param>
        /// <param name="userData">用户自定义数据。</param>
        /// <returns>声音的序列编号。</returns>
        int PlaySound(string soundAssetName, string soundGroupName, PlaySoundParams playSoundParams, object userData);

        /// <summary>
        /// 停止播放声音。
        /// </summary>
        /// <param name="serialId">要停止播放声音的序列编号。</param>
        /// <returns>是否停止播放声音成功。</returns>
        bool StopSound(int serialId);

        /// <summary>
        /// 停止播放声音。
        /// </summary>
        /// <param name="serialId">要停止播放声音的序列编号。</param>
        /// <param name="fadeOutSeconds">声音淡出时间，以秒为单位。</param>
        /// <returns>是否停止播放声音成功。</returns>
        bool StopSound(int serialId, float fadeOutSeconds);

        /// <summary>
        /// 暂停播放声音。
        /// </summary>
        /// <param name="serialId">要暂停播放声音的序列编号。</param>
        /// <returns>是否暂停播放声音成功。</returns>
        bool PauseSound(int serialId);

        /// <summary>
        /// 暂停播放声音。
        /// </summary>
        /// <param name="serialId">要暂停播放声音的序列编号。</param>
        /// <param name="fadeOutSeconds">声音淡出时间，以秒为单位。</param>
        /// <returns>是否暂停播放声音成功。</returns>
        bool PauseSound(int serialId, float fadeOutSeconds);

        /// <summary>
        /// 恢复播放声音。
        /// </summary>
        /// <param name="serialId">要恢复播放声音的序列编号。</param>
        /// <returns>是否恢复播放声音成功。</returns>
        bool ResumeSound(int serialId);

        /// <summary>
        /// 恢复播放声音。
        /// </summary>
        /// <param name="serialId">要恢复播放声音的序列编号。</param>
        /// <param name="fadeInSeconds">声音淡入时间，以秒为单位。</param>
        /// <returns>是否恢复播放声音成功。</returns>
        bool ResumeSound(int serialId, float fadeInSeconds);

        /// <summary>
        /// 停止所有声音。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        void StopAllSounds(string soundGroupName);

        /// <summary>
        /// 停止所有声音。
        /// </summary>
        /// <param name="soundGroupName">声音组名称。</param>
        /// <param name="fadeOutSeconds">声音淡出时间，以秒为单位。</param>
        void StopAllSounds(string soundGroupName, float fadeOutSeconds);

        /// <summary>
        /// 停止所有声音。
        /// </summary>
        void StopAllSounds();

        /// <summary>
        /// 停止所有声音。
        /// </summary>
        /// <param name="fadeOutSeconds">声音淡出时间，以秒为单位。</param>
        void StopAllSounds(float fadeOutSeconds);
    }
}
